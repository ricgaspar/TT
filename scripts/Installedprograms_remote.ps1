param(
[string]$computer,
[string]$script
)
$cil = "\\$computer\c$\Temp\Installedprograms.vbs"
if(Test-Path -Path $computer\c$\Temp)
{
    Copy-Item -Path $script -Destination $computer\c$\Temp
}
else{
    New-Item -Path $computer\c$\Temp -ItemType Directory
    Copy-Item -Path $script -Destination $computer\c$\Temp
}
Start-Process -Wait "C:\Systernals\psexec" -ArgumentList "$computer c:\windows\system32\cscript.exe $cil"
Del -Path $cil
if(!(Test-Path -Path "C:\ProgramData\TechnolToolkit\InstalledPrograms$computer"))
{
    New-Item -Path "C:\ProgramData\TechnolToolkit\InstalledPrograms$computer" -ItemType Directory
}
$datum = Get-Date -UFormat "%Y_%m_%d_%H_%M_%S"
Get-Content -Path "$computer\c$\Temp\InstalledPrograms.log" >> "C:\ProgramData\TechnolToolkit\InstalledPrograms\$computer\InstalledPrograms_$datum.log"
Del -Path "$computer\c$\Temp\InstalledPrograms.log" -Force