#!/usr/bin/env bash

NOINIT=0
BUILD_ARGUMENTS=()
for i in "$@"; do
    case ${1,,} in
        -noinit) NOINIT=1;;
        *) BUILD_ARGUMENTS+=("$1") ;;
    esac
    shift
done

set -eo pipefail
SCRIPT_DIR=$(cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd)

###########################################################################
# CONFIGURATION
###########################################################################

NUGET_URL="_NUGET_URL_"
SOLUTION_DIRECTORY="$SCRIPT_DIR/_SOLUTION_DIRECTORY_"
BUILD_PROJECT_FILE="$SCRIPT_DIR/_BUILD_DIRECTORY_NAME_/_BUILD_PROJECT_NAME_.csproj"
BUILD_EXE_FILE="$SCRIPT_DIR/_BUILD_DIRECTORY_NAME_/bin/Debug/_BUILD_PROJECT_NAME_.exe"
TEMP_DIRECTORY="$SCRIPT_DIR/_ROOT_DIRECTORY_/.tmp"

###########################################################################
# PREPARE BUILD
###########################################################################

if ! ((NOINIT)); then
  mkdir -p $TEMP_DIRECTORY

  NUGET_FILE="$TEMP_DIRECTORY/nuget.exe"
  export NUGET_EXE="$NUGET_FILE"
  if [ ! -f $NUGET_FILE ]; then curl -Lsfo $NUGET_FILE $NUGET_URL;
  elif [[ $NUGET_URL == *"latest"* ]]; then mono $NUGET_FILE update -Self; fi

  mono $NUGET_FILE restore $BUILD_PROJECT_FILE -SolutionDirectory $SOLUTION_DIRECTORY
fi

msbuild $BUILD_PROJECT_FILE

###########################################################################
# EXECUTE BUILD
###########################################################################

mono $BUILD_EXE_FILE ${BUILD_ARGUMENTS[@]}
