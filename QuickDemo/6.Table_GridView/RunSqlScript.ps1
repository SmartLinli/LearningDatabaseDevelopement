& sqlcmd -S "(local)" -i "InitDb.sql"
Write-Host '�밴���������' -NoNewline
$null = [Console]::ReadKey('?')