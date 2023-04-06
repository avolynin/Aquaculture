@echo off

echo Build...
dotnet build src -c Release %*
if %ERRORLEVEL% neq 0 goto error

pause
exit /b 0
:error
pause
exit /b 1