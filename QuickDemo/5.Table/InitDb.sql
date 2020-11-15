/*
��
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
	('3190707001','������','Ů','2001-05-08','19�Ź�','˯��')
	,('3190707002','������','Ů','2001-05-20','19�Ź�','�Ի�')
	,('3190707003','�ź���','��','2001-04-27','19�Ź�',NULL)
	,('3190707004','������','��','2000-07-08','19�Ź�',NULL);
/*
������ͼ
*/
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
	('3190707001','A001',82);