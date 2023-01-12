/*
��_��
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
----�γ̱�
CREATE TABLE tb_Course
	(No
		CHAR(4)
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(50)
		NOT NULL
	,Pinyin
		VARCHAR(50)
		NULL
	,PreCourseNo
		CHAR(4)
		NULL
	,Credit
		DECIMAL(3,1)
		NOT NULL
		DEFAULT(3.0)
	,StudyType
		VARCHAR(20)
		NOT NULL
	,ExamType
		VARCHAR(10)
		NOT NULL);
----��������γ̱�
BULK INSERT tb_Course
	FROM 'C:\Course.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);
----ѡ�α�
GO
CREATE TABLE tb_SelectedCourse
	(StudentNo
		CHAR(10)
		NOT NULL
	,CourseNo
		CHAR(4)
		NOT NULL
		FOREIGN KEY REFERENCES tb_Course(No)
	,OrderBook
		BIT
		NOT NULL);
INSERT tb_SelectedCourse
    (StudentNo,CourseNo,OrderBook )
	VALUES
	('3210707001','E003',1)
	,('3210707001','F001',1)
GO
--������ͼ��
----��ѡ�γ���Ϣ
CREATE OR ALTER VIEW vw_SelectedCourseInfo
	AS
SELECT 
		C.No
		,C.Name
		,C.Credit
		,SC.OrderBook
	FROM
		tb_Course AS C
		JOIN tb_SelectedCourse AS SC ON SC.CourseNo = C.No;
GO