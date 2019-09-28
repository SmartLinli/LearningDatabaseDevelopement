/*此脚本包含中文数据，可使用记事本将此文件保存为ANSI编码；或使用VSCode保存为GBK编码。使用PgAdmin4则导致乱码。*/
DROP TABLE IF EXISTS "Class" CASCADE;
--班级表
CREATE TABLE "Class"
	("No"
		INT
		NOT NULL
		PRIMARY KEY
	,"Name"
		VARCHAR(20)
		NOT NULL);
INSERT INTO "Class"
	("No","Name")
	VALUES
	(1,'12卫管')
	,(2,'12信管')
	,(3,'12中医')
	,(4,'12临床');
DROP TABLE IF EXISTS "Student" CASCADE;
--学生表；
CREATE TABLE "Student"
	("No"
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,"Name"
		TEXT
		NOT NULL
	,"Gender"
		BOOLEAN
		NOT NULL
	,"BirthDate"
		DATE
		NOT NULL
	,"Speciality"
		VARCHAR(100)
		NULL
	,"ClassNo"
		INT
		NOT NULL
		REFERENCES "Class"("No"));
INSERT INTO "Student"
	("No","Name","Gender","BirthDate","Speciality","ClassNo")
	VALUES
	('3120707001','田永申',TRUE,'1991-10-15','睡觉',2);