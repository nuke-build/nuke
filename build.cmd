@echo off
powershell -ExecutionPolicy ByPass -NoProfile %0\..\build.ps1 %*
