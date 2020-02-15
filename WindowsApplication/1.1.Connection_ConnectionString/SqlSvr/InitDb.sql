/*
连接_连接字符串
*/
--创建数据库；
USE master;
IF DB_ID('EduBaseDemo2020') IS NOT NULL
	BEGIN
		ALTER DATABASE EduBaseDemo2020
			SET SINGLE_USER
			WITH ROLLBACK IMMEDIATE;
		DROP DATABASE EduBaseDemo2020;
	END
GO	
CREATE DATABASE EduBaseDemo2020
	ON
		(NAME='Datafile'
		,FILENAME='C:\DataFile2020.mdf')
	LOG ON
		(NAME='Logfile'
		,FILENAME='C:\Logfile2020.ldf');