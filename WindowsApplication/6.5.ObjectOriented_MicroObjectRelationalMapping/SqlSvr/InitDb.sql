/*
�������_�����������ϵӳ��
*/
--�������ݿ⣻
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
--������
----�û���
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
	('3210707001',HASHBYTES('MD5','7001'),1);
GO
USE EduBaseDemo;
--�����洢���̣�
----�����û��Ų�ѯ�û�������
GO
CREATE OR ALTER PROCEDURE usp_selectUserCount
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
----�����û��Ų�ѯ�û���
GO
CREATE OR ALTER PROCEDURE usp_selectUser
	(@No CHAR(10))
	AS
BEGIN
	SELECT	 
			U.No
			,U.Password
			,U.IsActivated
			,U.LoginFailCount
		FROM
			tb_User AS U
		WHERE
			U.No=@No;
END
----�����û���
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
----�����û���
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