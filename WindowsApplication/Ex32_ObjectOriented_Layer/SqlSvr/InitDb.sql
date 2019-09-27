/*
例3.2_面向对象_分层
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
		DEFAULT 0);
INSERT tb_User
	(No,Password,IsActivated)
	VALUES
	('3180707001',HASHBYTES('MD5','7001'),1);
GO
USE EduBaseDemo;
--创建存储过程；
----根据用户号查询用户计数；
GO
CREATE OR ALTER PROCEDURE usp_selectUserCountByNo
	(@No CHAR(10))
	AS
BEGIN
	SELECT 
			COUNT(1)
		FROM
			tb_User AS U
		WHERE
			U.No=@No;
END
----根据用户号查询用户；
GO
CREATE OR ALTER PROCEDURE usp_selectUserByNo
	(@No CHAR(10))
	AS
BEGIN
	SELECT	 
			U.Password
			,U.IsActivated
			,U.LoginFailCount
		FROM
			tb_User AS U
		WHERE
			U.No=@No;
END
----更新用户；
GO
CREATE OR ALTER PROCEDURE usp_updateUser
	(@No CHAR(10)
	,@Password VARBINARY(128)
	,@IsActivated BIT
	,@LoginFailCount INT)
	AS
BEGIN
	UPDATE tb_User
		SET 
			Password=@Password
			,IsActivated=@IsActivated
			,LoginFailCount=@LoginFailCount
		WHERE No=@No;
END
----插入用户；
GO
CREATE OR ALTER PROCEDURE usp_insertUser
	(@No CHAR(10)
	,@Password VARBINARY(128)
	,@IsActivated BIT)
	AS
BEGIN
	INSERT tb_User
		(No,Password,IsActivated)
		VALUES
		(@No
		,@Password
		,@IsActivated);
END