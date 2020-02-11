/*
表_分页
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
----学生表；
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
		NOT NULL);
----批量插入学生表；
BULK INSERT tb_Student
	FROM 'C:\Student.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);
----课程表；
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
	,StudyTypeNo
		VARCHAR(20)
		NOT NULL
	,ExamTypeNo
		VARCHAR(10)
		NOT NULL);
----批量插入课程表；
BULK INSERT tb_Course
	FROM 'C:\Course.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);
----学生成绩表；
CREATE TABLE tb_StudentScore
	(StudentNo
		CHAR(10)
		NOT NULL
		FOREIGN KEY REFERENCES tb_Student(No)
			ON UPDATE CASCADE
			ON DELETE CASCADE
	,CourseNo
		CHAR(4)
		NOT NULL
		FOREIGN KEY REFERENCES tb_Course(No)
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
BULK INSERT tb_StudentScore
	FROM 'C:\StudentScore.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);