/*
����_�洢����
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
		NOT NULL);
INSERT tb_User
	(No,Password)
	VALUES
	('3210707001',HASHBYTES('MD5','7001'));
GO
USE EduBaseDemo;
--�����洢���̣�
----��ѯ�û�������
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
----�����û���
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
			THROW 52627, '��ע����û����Ѵ��ڣ����������룡',11;
		ELSE
			THROW;
	END CATCH
END
----�����û����룻
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