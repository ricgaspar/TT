$pshost = get-host
$pswindow = $pshost.ui.rawui
$newsize = $pswindow.buffersize
$newsize.height = 300
$newsize.width = 150
$pswindow.buffersize = $newsize
$newsize = $pswindow.windowsize
$newsize.height = 50
$newsize.width = 150
$pswindow.windowsize = $newsize
$pswindow.windowtitle = “Remote Dialog (zprava)”

$compname = read-host "Computername/IP"
$msg = read-host "Zprava v uvozovkach"
$tm = Read-Host "Doba po kterou bude zpráva viditelná"
Invoke-WmiMethod -Path Win32_Process -Name Create -ArgumentList "msg * /time:$tm `"$msg`"" -ComputerName $compname