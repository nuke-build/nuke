#!/usr/bin/env bash

SCRIPT_ARGUMENTS=()
for i in "$@"; do
    case $1 in
        -n|--noinit) NOINIT=1; shift;;
        -t|--target) TARGET="$2"; shift ;;
        -c|--configuration) CONFIGURATION="$2"; shift ;;
        -v|--verbosity) VERBOSITY="$2"; shift ;;
        --) shift; SCRIPT_ARGUMENTS+=("$@"); break ;;
        *) SCRIPT_ARGUMENTS+=("$1") ;;
    esac
    shift
done

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

mono $BUILD_EXE_FILE --verbosity=$VERBOSITY --configuration=$CONFIGURATION --target=$TARGET $DRYRUN "${SCRIPT_ARGUMENTS[@]}"
