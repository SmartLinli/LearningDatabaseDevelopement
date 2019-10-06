/*此脚本包含中文数据，可使用记事本将此文件保存为ANSI编码；或使用VSCode保存为GBK编码。使用PgAdmin4则导致乱码。*/
DROP TABLE IF EXISTS "Table1" CASCADE;
--创建表；
CREATE TABLE "Table1"
	("No"
		INT
		NOT NULL
		PRIMARY KEY
	,"Name"
		VARCHAR(20)
		NOT NULL);
INSERT INTO "Table1"
	("No","Name")
	VALUES
	(1,'值11')
	,(2,'值12');
DROP TABLE IF EXISTS "Table2" CASCADE;
--创建表；
CREATE TABLE "Table2"
	("No"
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,"Name"
		VARCHAR(20)
		NOT NULL

	,"Table1No"
		INT
		NOT NULL
		REFERENCES "Table1"("No"));
INSERT INTO "Table2"
	("No","Name","Table1No")
	VALUES
	('1110101001','值21',2);