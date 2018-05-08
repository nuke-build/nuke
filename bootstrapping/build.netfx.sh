#!/usr/bin/env bash

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

SOLUTION_DIRECTORY="$SCRIPT_DIR/_SOLUTION_DIRECTORY_"
BUILD_PROJECT_FILE="$SCRIPT_DIR/_BUILD_DIRECTORY_NAME_/_BUILD_PROJECT_NAME_.csproj"
BUILD_EXE_FILE="$SCRIPT_DIR/_BUILD_DIRECTORY_NAME_/bin/Debug/_BUILD_PROJECT_NAME_.exe"
TEMP_DIRECTORY="$SCRIPT_DIR/_ROOT_DIRECTORY_/.tmp"

NUGET_VERSION="_NUGET_VERSION_"
NUGET_URL="https://dist.nuget.org/win-x86-commandline/$NUGET_VERSION/nuget.exe"

###########################################################################
# EXECUTION
###########################################################################

if ! ((LOCAL)) && [ -x "$(command -v nuget)" ]; then
    export NUGET_EXE="$(command -v nuget)"
else
    export NUGET_EXE="$TEMP_DIRECTORY/nuget.exe"
  
    if [ ! -f "$NUGET_EXE" ]; then
        mkdir -p "$TEMP_DIRECTORY"
        curl -Lsfo "$NUGET_EXE" "$NUGET_URL"
    elif [ "$NUGET_VERSION" == "latest" ]; then
        mono "$NUGET_EXE" update -Self
    fi
fi

mono "$NUGET_EXE" restore "$BUILD_PROJECT_FILE" -SolutionDirectory "$SOLUTION_DIRECTORY"
msbuild "$BUILD_PROJECT_FILE"

mono "$BUILD_EXE_FILE" ${BUILD_ARGUMENTS[@]}
