/*
例3.8_面向对象_数据传输对象
*/
--创建数据库；
USE master;
IF DB_ID('EduBaseDemo') IS NOT NULL
	BEGIN
		ALTER DATABASE EduBaseDemo
			SET SINGLE_USER
			WITH ROLLBACK IMMEDIATE;
		DROP DATABASE EduBaseDemo;
	END
GO
CREATE DATABASE EduBaseDemo
	ON
		(NAME='Datafile'
		,FILENAME='C:\DataFile.mdf')
	LOG ON
		(NAME='Logfile'
		,FILENAME='C:\Logfile.ldf');
GO
USE EduBaseDemo;
--创建表；
----角色表；
CREATE TABLE Role
	(No
		INT
		IDENTITY(1,1)
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(10)
		NOT NULL
		UNIQUE);
INSERT Role
	(Name)
	VALUES
	('学生')
	,('教师');
----用户表；
CREATE TABLE [User]
	(No
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,Password
		VARBINARY(128)
		NOT NULL
	,IsActivated
		BIT
		NOT NULL
	,LoginFailCount
		INT
		NOT NULL
		DEFAULT 0
	,RoleNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES Role(No));
INSERT [User]
	(No,Password,IsActivated,RoleNo)
	VALUES
	('3180707001',HASHBYTES('MD5','7001'),1,1);
GO