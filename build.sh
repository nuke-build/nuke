#!/usr/bin/env bash

NOINIT=0
REFEXT="False"
BUILD_ARGUMENTS=()
for i in "$@"; do
    case ${1,,} in
        -noinit) NOINIT=1;;
        -refext) REFLOCAL="True";;
        *) BUILD_ARGUMENTS+=("$1") ;;
    esac
    shift
done

set -eo pipefail
SCRIPT_DIR=$(cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd)

###########################################################################
# CONFIGURATION
###########################################################################

NUGET_URL="https://dist.nuget.org/win-x86-commandline/v4.1.0/nuget.exe"
SOLUTION_DIRECTORY="$SCRIPT_DIR/"
BUILD_PROJECT_FILE="$SCRIPT_DIR/build/.build.csproj"
BUILD_EXE_FILE="$SCRIPT_DIR/build/bin/Debug/.build.exe"
TEMP_DIRECTORY="$SCRIPT_DIR/.tmp"

###########################################################################
# PREPARE BUILD
###########################################################################

if ! ((NOINIT)); then
  mkdir -p $TEMP_DIRECTORY

  NUGET_FILE="$TEMP_DIRECTORY/nuget.exe"
  export NUGET_EXE="$NUGET_FILE"
  if [ ! -f $NUGET_FILE ]; then curl -Lsfo $NUGET_FILE $NUGET_URL;
  elif [[ $NUGET_URL == *"latest"* ]]; then mono $NUGET_FILE update -Self; fi
fi

msbuild $BUILD_PROJECT_FILE /target:"Restore;Build" /property:"ReferenceExternal=$REFEXT"

###########################################################################
# EXECUTE BUILD
###########################################################################

mono $BUILD_EXE_FILE ${BUILD_ARGUMENTS[@]}
