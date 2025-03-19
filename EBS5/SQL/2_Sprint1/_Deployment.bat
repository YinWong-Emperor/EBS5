@REM -------Config-------------
@SET DB_IP=172.30.1.80\DB05
@SET DB_Name=ESL_Dev_Test
@SET DB_USER=sa
@SET DB_PWD=sa


@call:GenerateTimeStamp
@SET LOG=_Deployment_%TimeStamp%.log



@REM -------环境处理-----------
@cls
@title ESL database scripts
@color 3f
@echo Database：[%DB_Name%] from [%DB_IP%]
@echo Database：[%DB_Name%] from [%DB_IP%] > %LOG%
@echo.
@echo Creating scripts...
@echo.


@REM -------开始预生成内容-----
@echo SET NOCOUNT ON > .\_DeployListScripts.sql
@echo GO >> .\_DeployListScripts.sql


@REM -------#1表-----------
@call:LOOP_DEAL_SQL_FILES_FROM_DIR .\Tables

@REM -------#2函数---------
@call:LOOP_DEAL_SQL_FILES_FROM_DIR .\Functions

@REM -------#3视图---------
@call:LOOP_DEAL_SQL_FILES_FROM_DIR .\Views

@REM -------#4存储过程-----
@call:LOOP_DEAL_SQL_FILES_FROM_DIR .\StoredProcedures

@REM -------#5数据---------
@call:LOOP_DEAL_SQL_FILES_FROM_DIR .\Datas


@REM -------#9结尾---------
@echo PRINT ''>> .\_DeployListScripts.sql
@echo PRINT 'All Script Execute Successfully!'>> .\_DeployListScripts.sql


@echo run scripts...
@echo.
@REM -------开始执行脚本-----
@SQLCMD -S %DB_IP% -U %DB_USER% -P %DB_PWD% -d %DB_Name% -i .\_DeployListScripts.sql -b >> %LOG%


@IF %errorlevel% NEQ 0 goto err_handler

@echo Successfully! 
@REM @echo Successfully! Please See log file: %LOG%
@goto exit



@REM 遍历指定目录的所有*.sql文件并处理
:LOOP_DEAL_SQL_FILES_FROM_DIR
@SET TMP_NAME=%~1 
@SET TMP_NAME=%TMP_NAME:~2,-1%
@echo:>> .\_DeployListScripts.sql
@echo:>> .\_DeployListScripts.sql
@echo PRINT '-------- Executing %TMP_NAME% --------'>> .\_DeployListScripts.sql

@FOR /r %~1 %%i in (*.sql) DO @(
echo PRINT '%~1\%%~nxi' >> .\_DeployListScripts.sql
echo :r "%~1\%%~nxi">> .\_DeployListScripts.sql
echo:>> .\_DeployListScripts.sql
)
@GOTO:EOF  

@REM 生成时间戳，用来给日志文件唯一命名
:GenerateTimeStamp
@SETLOCAL
@If "%date%A" LSS "A" @(Set _NumTok=1-3) Else @(Set _NumTok=2-4)
@For /F "TOKENS=2*" %%A In ('REG QUERY "HKCU\Control Panel\International" /v iDate') Do @Set _iDate=%%B
@For /F "TOKENS=2*" %%A In ('REG QUERY "HKCU\Control Panel\International" /v sDate') Do @Set _sDate=%%B
@IF %_iDate%==0 For /F "TOKENS=%_NumTok% DELIMS=%_sDate% " %%B In ("%date%") Do @Set _fdate=%%D%%B%%C
@IF %_iDate%==1 For /F "TOKENS=%_NumTok% DELIMS=%_sDate% " %%B In ("%date%") Do @Set _fdate=%%D%%C%%B
@IF %_iDate%==2 For /F "TOKENS=%_NumTok% DELIMS=%_sDate% " %%B In ("%date%") Do @Set _fdate=%%B%%C%%D
@ENDLOCAL&SET "TimeStamp=%_fdate:~0,4%%_fdate:~4,2%%_fdate:~6,2%_%Time:~0,2%%Time:~3,2%%Time:~6,2%"
@GOTO:EOF 



@REM 错误处理
:err_handler
@color 4f
@REM @echo Failed! Please See log file: %LOG%
@TYPE .\%LOG%
@goto exit

@REM 退出
:exit
@echo Press any key to continue...
@PAUSE > nul
@exit