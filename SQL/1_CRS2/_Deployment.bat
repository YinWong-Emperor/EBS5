@REM -------Config-------------
@SET DB_IP=172.19.249.39
@SET DB_Name=ESL
@SET DB_USER=sa
@SET DB_PWD=sa


@REM -------环境处理-----------
@cls
@title ESL database scripts
@color 3f
@echo Database：[%DB_Name%] from [%DB_IP%]
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


@REM -------#3存储过程-----
@call:LOOP_DEAL_SQL_FILES_FROM_DIR .\StoredProcedures


@REM -------#4数据---------
@call:LOOP_DEAL_SQL_FILES_FROM_DIR .\Datas


@REM -------#5视图---------
@call:LOOP_DEAL_SQL_FILES_FROM_DIR .\Views


@REM -------#9结尾---------
@echo PRINT ''>> .\_DeployListScripts.sql
@echo PRINT 'All Script Execute Successfully!'>> .\_DeployListScripts.sql


@echo run scripts...
@echo.
@REM -------开始执行脚本-----
@SQLCMD -E -d %DB_Name% -i .\_DeployListScripts.sql -o .\_Deployment.log -b


@IF %errorlevel% NEQ 0 goto err_handler

@echo Successfully! Please See log file: _Deployment.log
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

@REM 错误处理
:err_handler
@color 4f
@echo Failed! Please See log file: _Deployment.log
@goto exit

@REM 退出
:exit
@echo Press any key to continue...
@PAUSE > nul
@del /s .\_DeployListScripts.sql > nul
@start .\_Deployment.log
@exit