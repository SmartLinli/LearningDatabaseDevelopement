/*
��_������ͼ
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
----�γ̱�
CREATE TABLE tb_Course
	(Number 
		CHAR(4) 
		NOT NULL 
		PRIMARY KEY
	,Name 
		VARCHAR(50) 
		NOT NULL);
INSERT tb_Course
	(Number,Name)
	VALUES
	('A001','�������������')
	,('A002','���ݿ�ԭ��')
	,('A003','���ݿ⼼����Ӧ��');
----ѧ���ɼ���
CREATE TABLE tb_StudentScore
	(StudentNumber 
		CHAR(10) 
		NOT NULL
	,CourseNumber 
		CHAR(4) 
		NOT NULL
	,Score 
		DECIMAL(4,1) 
		NULL
	,PRIMARY KEY(StudentNumber,CourseNumber));
INSERT tb_StudentScore
	(StudentNumber,CourseNumber,Score)
	VALUES
	('3210707001','A001',82);