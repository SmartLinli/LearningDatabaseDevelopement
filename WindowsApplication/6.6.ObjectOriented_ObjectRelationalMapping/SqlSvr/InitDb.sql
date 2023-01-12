/*
�������_�����ϵӳ��
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