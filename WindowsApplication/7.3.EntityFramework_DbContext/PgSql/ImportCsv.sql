\set ON_ERROR_STOP 1
\set ECHO all
\c EduBaseDemo;
COPY "tb_Class"
FROM 'C:\Class.csv' DELIMITER ',' CSV HEADER;
COPY "tb_Student"
FROM 'C:\Student.csv' DELIMITER ',' CSV HEADER;