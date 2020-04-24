@echo off
call :CurDIR "%cd%"
pause  
goto :eof  
:CurDIR  

set "year=%date:~0,4%"
set "month=%date:~5,2%"
set "day=%date:~8,2%"
set "hour_ten=%time:~0,1%"
set "hour_one=%time:~1,1%"
set "minute=%time:~3,2%"
set "second=%time:~6,2%"
set "name_befor=%~nx1"
if "%hour_ten%" == " " (
    set "rar_name=%year%%month%%day%Release.rar "
) else (
    set "rar_name=%year%%month%%day%Release.rar "
)


set rar=%ProgramFiles%/WinRAR\Rar.exe

"%rar%" a -r -ep1 ./"%rar_name%" ./bin/Release

echo "%~dp0%"
echo " %rar_name%"
pause
