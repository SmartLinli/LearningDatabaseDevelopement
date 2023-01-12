DROP TABLE IF EXISTS tb_user CASCADE;
--”√ªß±Ì£ª
CREATE TABLE tb_user
	(no
		CHAR(10)
		NOT NULL
		PRIMARY KEY
	,password
		BYTEA
		NOT NULL
	,is_activated
		BOOLEAN
	 	NOT NULL
	,login_fail_count
		INTEGER
		NOT NULL
		DEFAULT 0);
INSERT INTO tb_user
	(no,password,is_activated)
	VALUES
	('3210707001',DECODE(MD5('7001'),'HEX'),TRUE);