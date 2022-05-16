@echo off
md C:\EduBaseDemo
psql -U Administrator -d postgres -f PSqlBatch.sql
pause