/*
面向对象_数据传输对象
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
CREATE TABLE tb_Role
	(No
		INT
		IDENTITY(1,1)
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(10)
		NOT NULL
		UNIQUE);
INSERT tb_Role
	(Name)
	VALUES
	('学生')
	,('教师');
----用户表；
CREATE TABLE tb_User
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
		FOREIGN KEY REFERENCES tb_Role(No));
INSERT tb_User
	(No,Password,IsActivated,RoleNo)
	VALUES
	('3210707001',HASHBYTES('MD5','7001'),1,1)
	,('2004034',HASHBYTES('MD5','1234'),1,2);
GO