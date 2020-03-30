/*
实体框架_增查改删
*/
--创建数据库；
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
--创建表；
----院系表；
CREATE TABLE Department
	(No
		INT
		NOT NULL
		PRIMARY KEY
	,Name
		VARCHAR(20)
		NOT NULL);
INSERT Department
	(No,Name)
	VALUES
	(1,'管理学院')
	,(2,'中医学院');
----专业表；
CREATE TABLE Major
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
		FOREIGN KEY REFERENCES Department(No)
			ON UPDATE CASCADE
			ON DELETE NO ACTION);
INSERT Major
	(No,Name,DepartmentNo)
	VALUES
	(1,'公管',1)
	,(2,'信管',1)
	,(3,'中医',2)
	,(4,'临床',2);
----班级表；
CREATE TABLE Class
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
		FOREIGN KEY REFERENCES Major(No)
			ON UPDATE CASCADE
			ON DELETE NO ACTION)
INSERT Class
	(No,Name,MajorNo)
	VALUES
	(1,'18公管',1)
	,(2,'18信管',2)
	,(3,'18中医',3)
	,(4,'18临床',4);
----学生表；
CREATE TABLE Student
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
		FOREIGN KEY REFERENCES Class(No)
			ON UPDATE CASCADE
			ON DELETE NO ACTION);
----批量插入学生表；
BULK INSERT Student
	FROM 'C:\Student.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);
----课程表；
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
	,StudyTypeNo
		VARCHAR(20)
		NOT NULL
	,ExamTypeNo
		VARCHAR(10)
		NOT NULL);
----批量插入课程表；
BULK INSERT Course
	FROM 'C:\Course.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);
----学生成绩表；
CREATE TABLE StudentScore
	(StudentNo
		CHAR(10)
		NOT NULL
		FOREIGN KEY REFERENCES Student(No)
			ON UPDATE CASCADE
			ON DELETE CASCADE
	,CourseNo
		CHAR(4)
		NOT NULL
		FOREIGN KEY REFERENCES Course(No)
			ON UPDATE CASCADE
			ON DELETE NO ACTION
	,BasicScore
		DECIMAL(4,1)
		NULL
	,FinalScore
		DECIMAL(4,1)
		NULL
	,TotalScore
		DECIMAL(4,1)
		NULL
	,FacultyRate
		DECIMAL(4,1)
		NULL
	,LastModifyTime
		SMALLDATETIME
		NOT NULL
		DEFAULT(GETDATE())
	,PRIMARY KEY(StudentNo,CourseNo));
----批量插入学生成绩表；
BULK INSERT StudentScore
	FROM 'C:\StudentScore.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);