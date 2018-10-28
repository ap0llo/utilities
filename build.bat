@echo off
SET SOLUTIONPATH=%~dp0\src\Utilities.sln
SET LOGDIRPATH=%~dp0\Build
SET LOGFILEPATH=%LOGDIRPATH%\build.log
SET COMMONPARAMETERS=/p:Configuration=Release /M /fl /flp:verbosity=normal;Append;LogFile=%LOGFILEPATH%

IF NOT EXIST "%LOGDIRPATH%" mkdir "%LOGDIRPATH%"
IF EXIST "%LOGFILEPATH%" del "%LOGFILEPATH%"

REM Restore NuGet packages
CALL %~dp0\msbuild.bat %SOLUTIONPATH% /t:Restore %COMMONPARAMETERS%
IF ERRORLEVEL 1 EXIT /b 1

REM Build
CALL %~dp0\msbuild.bat %SOLUTIONPATH% /t:Build %COMMONPARAMETERS%  %*
IF ERRORLEVEL 1 EXIT /b 1

CALL %~dp0\msbuild.bat %~dp0\src\Utilities\Grynwald.Utilities.csproj /t:Pack %COMMONPARAMETERS% 
IF ERRORLEVEL 1 EXIT /b 1