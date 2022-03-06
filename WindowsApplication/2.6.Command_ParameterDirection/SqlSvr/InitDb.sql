/*
����_��������
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
	,LastLogInAddress
		VARCHAR(20)
		NULL);
INSERT tb_User
	(No,Password,LastLogInAddress)
	VALUES
	('3200707001',HASHBYTES('MD5','7001'),'192.168.1.10');
--�����洢���̣�
----��ѯ�û�������
GO
CREATE OR ALTER PROCEDURE usp_selectUserCount
	(@No CHAR(10)
	,@Password VARCHAR(20)
	,@RowCount TINYINT OUTPUT
	,@LastLogInAddress VARCHAR(20) OUTPUT)
	AS
BEGIN
	DECLARE 
		@tb_LastLogInAddress TABLE
			(LastLogInAddress
				VARCHAR(20));
	SELECT
		@RowCount=0;
	UPDATE tb_User
		SET
			LastLogInAddress=
				(SELECT
						C.client_net_address
					FROM
						sys.dm_exec_connections AS C
					WHERE
						C.session_id=@@SPID)
		OUTPUT deleted.LastLogInAddress
			INTO @tb_LastLogInAddress
		WHERE
			No=@No
			AND Password=HASHBYTES('MD5',@Password);
	SELECT 
			@RowCount=@@ROWCOUNT
			,@LastLogInAddress=L.LastLogInAddress
		FROM
			@tb_LastLogInAddress AS L
		WHERE
			@@ROWCOUNT=1;
END