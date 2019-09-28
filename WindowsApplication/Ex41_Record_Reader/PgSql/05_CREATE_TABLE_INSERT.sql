/*此脚本包含中文数据，可使用记事本将此文件保存为ANSI编码；或使用VSCode保存为GBK编码。使用PgAdmin4则导致乱码。*/
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
		CHAR(2)
		NOT NULL
	,"BirthDate"
		DATE
		NOT NULL
	,"Class"
		VARCHAR(50)
		NOT NULL
	,"Speciality"
		VARCHAR(100)
		NULL);
INSERT INTO "Student"
	("No","Name","Gender","BirthDate","Class","Speciality")
	VALUES
	('3120707001','田永申','男','1991-10-15','12信管','睡觉');