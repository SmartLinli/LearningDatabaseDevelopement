@echo off
psql -U Administrator -d postgres -f PSqlBatch.sql
pause