/*
��
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
		CHAR(2)
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
	('3210707001','��ܺ�','Ů','2001-09-10','21�Ź�','�ɷ�')
	,('3210707002','����','Ů','2003-02-09','21�Ź�','����')
	,('3210707003','������','��','2004-01-05','21�Ź�',NULL)
	,('3210707004','������','Ů','2002-11-12','21�Ź�',NULL);