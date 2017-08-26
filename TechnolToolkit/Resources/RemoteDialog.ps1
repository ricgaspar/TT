$pshost = get-host
$pswindow = $pshost.ui.rawui
$newsize = $pswindow.buffersize
$newsize.height = 200
$newsize.width = 120
$pswindow.buffersize = $newsize
$newsize = $pswindow.windowsize
$newsize.height = 30
$newsize.width = 120
$pswindow.windowsize = $newsize
$pswindow.windowtitle = “Remote Dialog (zprava)”

$compname = read-host "Computername/IP"
$msg = read-host "Zprava"
$tm = Read-Host "Doba po kterou bude zpráva viditelná"
Invoke-WmiMethod -Path Win32_Process -Name Create -ArgumentList "msg * /time:$tm `"$msg`"" -ComputerName $compname