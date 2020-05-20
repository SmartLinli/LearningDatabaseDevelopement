@echo off
copy data\*.* c:\
psql -U Administrator -d postgres -f ImportCsv.sql
pause