/*
���ݼ�_���ݹ�ϵ
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
----Ժϵ��
CREATE TABLE tb_Department
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL);
INSERT tb_Department
	(No,Name)
	VALUES
	(1,'����ѧԺ')
	,(2,'��ҽѧԺ');
----רҵ��
CREATE TABLE tb_Major
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,DepartmentNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Department(No));
INSERT tb_Major
	(No,Name,DepartmentNo)
	VALUES
	(1,'����',1)
	,(2,'�Ź�',1)
	,(3,'����',1)
	,(4,'��ҽ',2)
	,(5,'�ٴ�',2);
----�༶��
CREATE TABLE tb_Class
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL
	,MajorNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Major(No))
INSERT tb_Class
	(No,Name,MajorNo)
	VALUES
	(1,'20����1',1)
	,(2,'20����2',1)
	,(3,'20�Ź�',2)
	,(4,'20����',3)
	,(5,'20��ҽ',4)
	,(6,'20�ٴ�',5);
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
	,PoliticalStatus
		VARCHAR(100)
		NULL
	,Nationality
		VARCHAR(100)
		NULL
	,Province
		VARCHAR(100)
		NULL
	,City
		VARCHAR(100)
		NULL
	,GraduateFrom
		VARCHAR(100)
		NULL
	,IdentificationCard
		VARCHAR(100)
		NULL
	,Phone
		VARCHAR(100)
		NULL
	,Speciality
		VARCHAR(100)
		NULL
	,Photo
		VARBINARY(MAX)
		NULL	
	,ClassNo
		INT
		NOT NULL
		FOREIGN KEY REFERENCES tb_Class(No));
----��������ѧ����
BULK INSERT tb_Student
	FROM 'C:\Student.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);