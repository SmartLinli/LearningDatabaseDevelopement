/*�˽ű������������ݣ���ʹ�ü��±������ļ�����ΪANSI����*/
DROP TABLE IF EXISTS tb_role CASCADE;
--��ɫ��
CREATE TABLE tb_role
	(no
		SERIAL
		NOT NULL
		PRIMARY KEY
	,name
		VARCHAR(10)
		NOT NULL
		UNIQUE);
INSERT INTO tb_role
	(name)
	VALUES
	('ѧ��')
	,('��ʦ');
DROP TABLE IF EXISTS tb_user CASCADE;
--�û���
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
		DEFAULT 0
	,role_no
		INT
		NOT NULL
		REFERENCES tb_role(no));
INSERT INTO tb_user
	(no,password,is_activated,role_no)
	VALUES
	('3210707001',DECODE(MD5('7001'),'HEX'),TRUE,1)
	,('2004034',DECODE(MD5('1234'),'HEX'),TRUE,2);