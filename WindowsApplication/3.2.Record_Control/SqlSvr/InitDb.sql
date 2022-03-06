/*
��¼_�ؼ�
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
----�༶��
CREATE TABLE tb_Class
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL);
INSERT tb_Class
	(No,Name)
	VALUES
	(1,'20����')
	,(2,'20�Ź�')
	,(3,'20��ҽ')
	,(4,'20�ٴ�');
----ѧ����
CREATE TABLE tb_Student
	(No
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,Gender
		BIT
		NOT NULL
	,BirthDate
		DATE
		NOT NULL
	,ClassNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Class(No)
	,Speciality
		VARCHAR(100)
		NULL);
INSERT tb_Student
	(No,Name,Gender,BirthDate,ClassNo,Speciality)
	VALUES
	('3200707001','������',0,'2001-07-21',2,'˯��');
GO