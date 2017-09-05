#!/usr/bin/env bash

set -eo pipefail
SCRIPT_DIR=$(cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd)

###########################################################################
# CONFIGURATION
###########################################################################

BOOTSTRAPPING_URL="https://raw.githubusercontent.com/nuke-build/nuke/master/bootstrapping"
DEFAULT_NUGET_URL="https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
DEFAULT_BUILD_DIRECTORY_NAME="./build"
DEFAULT_BUILD_PROJECT_NAME=".build"

###########################################################################
# HELPER FUNCTIONS
###########################################################################

function ReadWithDefault {
    echo "$1. Leave blank for default: $2" > /dev/stderr
    read -p "Value: " prompt
    echo ${prompt:-$2}
}

function Download {
    mkdir -p "$(dirname "$2")"
    curl -Lsfo "$2" "$1"
}

function GetRelative {
    python -c "import os.path; print os.path.relpath('$2','${1:-$PWD}')"
}

function error {
    echo -e "\033[31;1m$*\033[0m"
    exit 1
}

###########################################################################
# LOCATE SOLUTION FILE
###########################################################################

ROOT_DIRECTORY="$SCRIPT_DIR"
while [[ $ROOT_DIRECTORY != / && ! -n "$(find "$ROOT_DIRECTORY" -maxdepth 1 -regex '.*/\.git')" ]]; do
    ROOT_DIRECTORY="$(dirname "$ROOT_DIRECTORY")"
done
if [ "$ROOT_DIRECTORY" == / ]; then ROOT_DIRECTORY="$SCRIPT_DIR"; fi
echo "Searching for solution files in '$ROOT_DIRECTORY' (2-levels)..."

SOLUTION_FILE_ARRAY=()
while IFS= read -r -d $'\0'; do
    SOLUTION_FILE_ARRAY+=("$REPLY")
done < <(find "$ROOT_DIRECTORY" -maxdepth 2 -name "*.sln" -print0)
if [ ${#SOLUTION_FILE_ARRAY[@]} == 0 ]; then error "No solution file (*.sln) could be found."; fi

SOLUTION_FILE_SELECTION=0
if [ ${#SOLUTION_FILE_ARRAY[@]} -gt 1 ]; then
    while : ; do
        echo "Found multiple solution files:"
        for i in "${!SOLUTION_FILE_ARRAY[@]}"; do
            TMP_SOLUTION_FILE="${SOLUTION_FILE_ARRAY[$i]}"
            echo "[$i] $(GetRelative "$SCRIPT_DIR" "$TMP_SOLUTION_FILE")"
        done
        read -p "Default solution file id: " SOLUTION_FILE_SELECTION
        [[ $SOLUTION_FILE_SELECTION < 0 || $SOLUTION_FILE_SELECTION -ge ${#SOLUTION_FILE_ARRAY[@]} ]] || break
    done
fi

SOLUTION_FILE="${SOLUTION_FILE_ARRAY[$SOLUTION_FILE_SELECTION]}"
SOLUTION_DIRECTORY="$(dirname "$SOLUTION_FILE")"
echo $(GetRelative "$ROOT_DIRECTORY" "$SOLUTION_FILE") > "$ROOT_DIRECTORY/.nuke"

echo "Using '$(GetRelative "$SCRIPT_DIR" "$SOLUTION_FILE")' as solution file."

###########################################################################
# GENERATE BUILD SCRIPTS
###########################################################################

NUGET_URL=$(ReadWithDefault "NuGet executable download url" $DEFAULT_NUGET_URL)
BUILD_DIRECTORY_NAME=$(ReadWithDefault "Directory for build project" $DEFAULT_BUILD_DIRECTORY_NAME)
BUILD_PROJECT_NAME=$(ReadWithDefault "Name for build project" $DEFAULT_BUILD_PROJECT_NAME)

echo "Generating build.ps1, build.sh and configuration file..."

SOLUTION_DIRECTORY_RELATIVE="$(GetRelative "$SCRIPT_DIR" "$SOLUTION_DIRECTORY")"
ROOT_DIRECTORY_RELATIVE="$(GetRelative "$SCRIPT_DIR" "$ROOT_DIRECTORY")"

sed -e 's~_NUGET_URL_~'"$NUGET_URL"'~g' \
    -e 's~_BUILD_DIRECTORY_NAME_~'"$BUILD_DIRECTORY_NAME"'~g' \
    -e 's~_BUILD_PROJECT_NAME_~'"$BUILD_PROJECT_NAME"'~g' \
    -e 's~_SOLUTION_DIRECTORY_~'"$SOLUTION_DIRECTORY_RELATIVE"'~g' \
    -e 's~_ROOT_DIRECTORY_~'"$ROOT_DIRECTORY_RELATIVE"'~g' \
    <<<"$(curl -Lsf $BOOTSTRAPPING_URL/build.sh)" \
    > build.sh
    
sed -e 's~_NUGET_URL_~'"$NUGET_URL"'~g' \
    -e 's~_BUILD_DIRECTORY_NAME_~'"$BUILD_DIRECTORY_NAME"'~g' \
    -e 's~_BUILD_PROJECT_NAME_~'"$BUILD_PROJECT_NAME"'~g' \
    -e 's~_SOLUTION_DIRECTORY_~'"${SOLUTION_DIRECTORY_RELATIVE//\//\\}"'~g' \
    -e 's~_ROOT_DIRECTORY_~'"${ROOT_DIRECTORY_RELATIVE//\//\\}"'~g' \
    <<<"$(curl -Lsf $BOOTSTRAPPING_URL/build.ps1)" \
    > build.ps1

###########################################################################
# DOWNLOAD NUGET.EXE
###########################################################################

echo "Downloading nuget.exe..."
NUGET_FILE="$ROOT_DIRECTORY/.tmp/nuget.exe"
Download $NUGET_URL $NUGET_FILE

###########################################################################
# GENERATE TEMPLATE FILES
###########################################################################

while : ; do
    echo "Which format do you want to use for your build project:"
    echo "[0] Legacy format. Supported by all MSBuild versions."
    echo "[1] SDK-based format. Requires MSBuild 15.0."
    read -p "Default solution file id: " FORMAT_SELECTION
    [[ $FORMAT_SELECTION < 0 || $FORMAT_SELECTION -ge 2 ]] || break
done

echo "Generating template files..."

BUILD_PROJECT_URL_ARRAY=("$BOOTSTRAPPING_URL/.build.legacy.csproj" "$BOOTSTRAPPING_URL/.build.sdk.csproj")
BUILD_PROJECT_URL=${BUILD_PROJECT_URL_ARRAY[$FORMAT_SELECTION]}
DOTSETTINGS_URL="$BOOTSTRAPPING_URL/.build.csproj.DotSettings"
DEFAULTBUILD_URL="$BOOTSTRAPPING_URL/Build.cs"

BUILD_DIRECTORY="$SCRIPT_DIR/$BUILD_DIRECTORY_NAME"
BUILD_PROJECT_FILE="$BUILD_DIRECTORY/$BUILD_PROJECT_NAME.csproj"
mkdir -p $(dirname $BUILD_DIRECTORY)

Download $BUILD_PROJECT_URL "$BUILD_PROJECT_FILE"
Download $DOTSETTINGS_URL "$BUILD_PROJECT_FILE.dotsettings"
Download $DEFAULTBUILD_URL "$BUILD_DIRECTORY/Build.cs"

PROJECTKIND_GUID_ARRAY=("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC" "9A19103F-16F7-4668-BE54-9A1E7A4F7556")
PROJECTKIND_GUID=${PROJECTKIND_GUID_ARRAY[$FORMAT_SELECTION]}
PROJECT_GUID=$(python -c "import uuid; print str(uuid.uuid4()).upper()")

if [ $FORMAT_SELECTION == 0 ]; then
    Download "$BOOTSTRAPPING_URL/.build.legacy.packages.config" "$BUILD_DIRECTORY/packages.config"

    SOLUTION_DIRECTORY_RELATIVE="$(GetRelative "$BUILD_DIRECTORY" "$SOLUTION_DIRECTORY")"
    sed -e 's~_BUILD_PROJECT_GUID_~'"$PROJECT_GUID"'~g' \
        -e 's~_BUILD_PROJECT_NAME_~'"$BUILD_PROJECT_NAME"'~g' \
        -e 's~_SOLUTION_DIRECTORY_~'"${SOLUTION_DIRECTORY_RELATIVE//\//\\}"'~g' \
        <<<"$(cat $BUILD_PROJECT_FILE)" \
        > $BUILD_PROJECT_FILE
        
    mono $NUGET_FILE restore $BUILD_PROJECT_FILE -SolutionDirectory $SOLUTION_DIRECTORY
    mono $NUGET_FILE update $BUILD_PROJECT_FILE
fi

###########################################################################
# ADD TO SOLUTION
###########################################################################

if ! grep -q "$BUILD_PROJECT_NAME.csproj" "$SOLUTION_FILE"; then
    echo "Adding $BuildProjectName project to solution..."

    BUILD_PROJECT_FILE_RELATIVE="$(GetRelative "$SOLUTION_DIRECTORY" "$BUILD_PROJECT_FILE")"

    PROJECT_DEFINITION='Project(\"{'$PROJECTKIND_GUID'}\") = \"'$BUILD_PROJECT_NAME'\", \"'${BUILD_PROJECT_FILE_RELATIVE//\//\\\\}'\", \"{'$PROJECT_GUID'}\"\nEndProject'
    PROJECT_CONFIGURATION='\t\t{'$PROJECT_GUID'}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n\t\t{'$PROJECT_GUID'}.Release|Any CPU.ActiveCfg = Release|Any CPU'
    
    awk "/MinimumVisualStudioVersion/{print \$0 RS \"$PROJECT_DEFINITION\";next}1" "$SOLUTION_FILE" > "$SOLUTION_FILE.bak"
    awk "/ProjectConfigurationPlatforms/{print \$0 RS \"$PROJECT_CONFIGURATION\";next}1" "$SOLUTION_FILE.bak" > "$SOLUTION_FILE"
    
    rm "$SOLUTION_FILE.bak"
fi

###########################################################################
# FINISH
###########################################################################

rm "${BASH_SOURCE[0]}"
echo "Finished setting up build project."
