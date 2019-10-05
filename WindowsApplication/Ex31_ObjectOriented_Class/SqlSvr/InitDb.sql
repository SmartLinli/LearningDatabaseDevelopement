/*
面向对象_类
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
		NOT NULL);
INSERT tb_User
	(No,Password)
	VALUES
	('3180707001',HASHBYTES('MD5','7001'));
GO
USE EduBaseDemo;
--创建存储过程；
----查询用户计数；
GO
CREATE OR ALTER PROCEDURE usp_selectUserCount
	(@No CHAR(10)
	,@Password VARCHAR(20))
	AS
BEGIN
	SELECT 
			COUNT(1)
		FROM
			tb_User AS U
		WHERE
			U.No=@No
			AND U.Password=HASHBYTES('MD5',@Password);
END
----插入用户；
GO
CREATE OR ALTER PROCEDURE usp_insertUser
	(@No CHAR(10)
	,@Password VARCHAR(20))
	AS
BEGIN
	BEGIN TRY    
		INSERT tb_User
			(No,Password)
			VALUES
			(@No
			,HASHBYTES('MD5',@Password));
	END TRY
	BEGIN CATCH
		IF ERROR_NUMBER()=2627
			THROW 52627, '您注册的用户号已存在，请重新输入！',11;
		ELSE
			THROW;
	END CATCH
END
----更新用户密码；
GO
CREATE OR ALTER PROCEDURE usp_updateUserPassword
	(@No CHAR(10)
	,@NewPassword VARCHAR(20))
	AS
BEGIN
	UPDATE tb_User
		SET
			Password=HASHBYTES('MD5',@NewPassword)
		WHERE
			No=@No;
END