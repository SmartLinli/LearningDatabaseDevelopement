/*
����_����
*/
--�������ݿ⣻
USE master;
DROP DATABASE IF EXISTS EduBaseDemo;
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
		VARCHAR(20)
		NOT NULL);