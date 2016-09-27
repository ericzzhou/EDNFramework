@ECHO OFF
REM The following directory is for .NET 4.0
set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%

echo %~dp0
echo Installing EDNFJob...
echo ---------------------------------------------------
InstallUtil.exe  %~dp0\DotNet.Framework.JobHost.exe
net start "EDNFJob" 
echo ---------------------------------------------------
echo Done.
pause