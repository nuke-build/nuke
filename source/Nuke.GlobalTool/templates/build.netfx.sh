#!/usr/bin/env bash

echo $(bash --version 2>&1 | head -n 1)

set -eo pipefail
SCRIPT_DIR=$(cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd)

###########################################################################
# CONFIGURATION
###########################################################################

SOLUTION_DIRECTORY="$SCRIPT_DIR/_SOLUTION_DIRECTORY_"
BUILD_PROJECT_FILE="$SCRIPT_DIR/_BUILD_DIRECTORY_/_BUILD_PROJECT_NAME_.csproj"
BUILD_EXE_FILE="$SCRIPT_DIR/_BUILD_DIRECTORY_/bin/Debug/_BUILD_PROJECT_NAME_.exe"
TEMP_DIRECTORY="$SCRIPT_DIR/_ROOT_DIRECTORY_/.tmp"

NUGET_VERSION="_NUGET_VERSION_"
NUGET_URL="https://dist.nuget.org/win-x86-commandline/$NUGET_VERSION/nuget.exe"

###########################################################################
# EXECUTION
###########################################################################

echo $(mono --version 2>&1 | head -n 1)

export NUGET_EXE="$TEMP_DIRECTORY/nuget.exe"
if [ ! -f "$NUGET_EXE" ]; then
    mkdir -p "$TEMP_DIRECTORY"
    curl -Lsfo "$NUGET_EXE" "$NUGET_URL"
elif [ "$NUGET_VERSION" == "latest" ]; then
    mono "$NUGET_EXE" update -Self
fi
echo $(mono "$NUGET_EXE" help 2>&1 | head -n 1)

mono "$NUGET_EXE" restore "$BUILD_PROJECT_FILE" -SolutionDirectory "$SOLUTION_DIRECTORY"
msbuild "$BUILD_PROJECT_FILE" /nodeReuse:false
mono "$BUILD_EXE_FILE" "$@"
