'Script ktery emuluje ipconfig /all command.  A pote vylistuje sitove disky. 
'MiK

Dim strComputer, CRLF
Dim colDrives, strMsg
Dim WSHNetwork

strComputer = "."
CRLF = Chr(13) & Chr(10)
Set NetworkPROP = WScript.CreateObject("WScript.Network")
Set objWMIService = GetObject _
    ("winmgmts:" & "!\\" & strComputer & "\root\cimv2")
Set colAdapters = objWMIService.ExecQuery _
    ("Select * from Win32_NetworkAdapterConfiguration Where IPEnabled = True")


For Each objAdapter in colAdapters
    Msgbox "UserName "  &Chr(9) & "=" & NetworkPROP.UserName  & CRLF &  _
	"Host name: " &Chr(9) & "=" & objAdapter.DNSHostName & CRLF &  _
                  "IP address: " &Chr(9) & "=" & objAdapter.IPAddress(i) & CRLF &  _
                  "Description: " &Chr(9) & "=" & objAdapter.Description & CRLF &  _
	"User Domain: " &Chr(9) & "=" & NetworkPROP.UserDomain & CRLF &  _
                  "Physical address: " &Chr(9) & "=" & objAdapter.MACAddress & CRLF &  _
                  "DHCP enabled: " &Chr(9) & "=" & objAdapter.DHCPEnabled,  _
	 vbinformation + vbOKOnly + vbmsgboxsetforeground,                       _ 
	"Network Properties"
Next

