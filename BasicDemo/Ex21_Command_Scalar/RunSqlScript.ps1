& sqlcmd -s "(local)" -i "InitDb.sql"
Write-Host '请按任意键继续' -NoNewline
$null = [Console]::ReadKey('?')