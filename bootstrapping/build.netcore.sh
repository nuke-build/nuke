#!/usr/bin/env bash

echo $(bash --version 2>&1 | head -n 1)

LOCAL=0
BUILD_ARGUMENTS=()
for i in "$@"; do
    case $(echo $1 | awk '{print tolower($0)}') in
        -local) LOCAL=1;;
        *) BUILD_ARGUMENTS+=("$1") ;;
    esac
    shift
done

set -eo pipefail
SCRIPT_DIR=$(cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd)

###########################################################################
# CONFIGURATION
###########################################################################

BUILD_PROJECT_FILE="$SCRIPT_DIR/_BUILD_DIRECTORY_NAME_/_BUILD_PROJECT_NAME_.csproj"
TEMP_DIRECTORY="$SCRIPT_DIR/_ROOT_DIRECTORY_/.tmp"

DOTNET_CHANNEL="2.0"
DOTNET_SCRIPT_URL="https://raw.githubusercontent.com/dotnet/cli/master/scripts/obtain/dotnet-install.sh"
DOTNET_DIRECTORY="$TEMP_DIRECTORY/dotnet-unix"

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_XMLDOC_MODE="skip"

###########################################################################
# EXECUTION
###########################################################################

if ! ((LOCAL)) && [ -x "$(command -v dotnet)" ]; then
    export DOTNET_EXE="$(command -v dotnet)"
else
    export DOTNET_EXE="$DOTNET_DIRECTORY/dotnet"
  
    if [ ! -f "$DOTNET_EXE" ]; then
        mkdir -p "$DOTNET_DIRECTORY"
        
        DOTNET_SCRIPT_FILE="$TEMP_DIRECTORY/dotnet-install.sh"
        curl -Lsfo "$DOTNET_SCRIPT_FILE" "$DOTNET_SCRIPT_URL"
        
        chmod +x "$DOTNET_SCRIPT_FILE"
        "$DOTNET_SCRIPT_FILE" --install-dir "$DOTNET_DIRECTORY" --channel "$DOTNET_CHANNEL" --no-path
    fi
fi
echo "Microsoft (R) .NET Core SDK version $("$DOTNET_EXE" --version)"

"$DOTNET_EXE" run --project "$BUILD_PROJECT_FILE" -- ${BUILD_ARGUMENTS[@]}
