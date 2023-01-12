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
CREATE TABLE Course
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
BULK INSERT Course
	FROM 'C:\Course.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);
----ѡ�α�
GO
CREATE TABLE SelectedCourse
	(StudentNo
		CHAR(10)
		NOT NULL
	,CourseNo
		CHAR(4)
		NOT NULL
		FOREIGN KEY REFERENCES Course(No)
	,OrderBook
		BIT
		NOT NULL
	,PRIMARY KEY(StudentNo,CourseNo));
INSERT SelectedCourse
    (StudentNo,CourseNo,OrderBook )
	VALUES
	('3210707001','E003',1)
	,('3210707001','F001',1);
GO
--������ͼ��
----��ѡ�γ���Ϣ
CREATE OR ALTER VIEW SelectedCourseInfo
	AS
SELECT 
		SC.StudentNo
		,C.No AS CourseNo
		,C.Name AS CourseName
		,C.Credit
		,SC.OrderBook
	FROM
		Course AS C
		JOIN SelectedCourse AS SC ON SC.CourseNo = C.No;
GO
--�����洢���̣�
----����ѡ�μ�¼��
CREATE OR ALTER PROCEDURE usp_Insert_SelectedCourse
	(@StudentNo CHAR(10)
	,@CourseNo CHAR(4)
	,@OrderBook BIT)
	AS
BEGIN
	INSERT SelectedCourse(StudentNo,CourseNo,OrderBook)
		VALUES( @StudentNo,@CourseNo,@OrderBook);
END
GO
----����ѡ�μ�¼��
CREATE OR ALTER PROCEDURE usp_Update_SelectedCourse
	(@StudentNo CHAR(10)
	,@CourseNo CHAR(4)
	,@OrderBook BIT)
	AS
BEGIN
	UPDATE SelectedCourse
		SET OrderBook=@OrderBook
		WHERE StudentNo=@StudentNo AND CourseNo=@CourseNo;
END