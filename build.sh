#!/usr/bin/env bash

LOCAL=0
REFEXT="False"
BUILD_ARGUMENTS=()
for i in "$@"; do
    case $(echo $1 | awk '{print tolower($0)}') in
        -local) LOCAL=1;;
        -refext) REFEXT="True";;
        *) BUILD_ARGUMENTS+=("$1") ;;
    esac
    shift
done

set -eo pipefail
SCRIPT_DIR=$(cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd)

###########################################################################
# CONFIGURATION
###########################################################################

BUILD_PROJECT_FILE="$SCRIPT_DIR/build/.build.csproj"
TEMP_DIRECTORY="$SCRIPT_DIR/.tmp"

DOTNET_VERSION="2.1.300-rc1-008673"
DOTNET_SCRIPT_URL="https://raw.githubusercontent.com/dotnet/cli/master/scripts/obtain/dotnet-install.sh"
DOTNET_DIRECTORY="$TEMP_DIRECTORY/dotnet-unix"

export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export NUGET_XMLDOC_MODE="skip"
# Workaround according to https://github.com/dotnet/sdk/issues/335#issuecomment-371444503
export FrameworkPathOverride=$(dirname $(which mono))/../lib/mono/4.6.1-api/

###########################################################################
# FIND/DOWNLOAD DOTNET; RUN BUILD
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
        "$DOTNET_SCRIPT_FILE" --install-dir "$DOTNET_DIRECTORY" --version "$DOTNET_VERSION" --no-path
    fi
fi

"$DOTNET_EXE" build "$BUILD_PROJECT_FILE" /p:"ReferenceExternal=$REFEXT"
"$DOTNET_EXE" run --project "$BUILD_PROJECT_FILE" -- ${BUILD_ARGUMENTS[@]}
