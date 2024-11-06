/*
��¼_����
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
	(1,'21����')
	,(2,'21�Ź�')
	,(3,'21��ҽ')
	,(4,'21�ٴ�');
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
	,Class
		VARCHAR(50)
		NOT NULL		
	,Speciality
		VARCHAR(100)
		NULL);
INSERT tb_Student
	(No,Name,Gender,BirthDate,Class,Speciality)
	VALUES
	('3210707001','��ܺ�',0,'2001-09-10','21�Ź�','�ɷ�');
GO