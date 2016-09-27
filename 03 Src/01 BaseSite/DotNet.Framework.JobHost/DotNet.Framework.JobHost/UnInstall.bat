@ECHO OFF
REM The following directory is for .NET 4.0
set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%
echo %~dp0
echo UnInstalling EDNFJob...
echo ---------------------------------------------------
net stop "EDNFJob"
InstallUtil.exe -u  %~dp0\DotNet.Framework.JobHost.exe
echo ---------------------------------------------------
echo Done.
pause