'tento skript je treba spustit s parametry! napr. "jmenoSkriptu.vbs computername Notepad++" - nize jsou popsany parametry co delaji
'objArgs(0) = computername
'objArgs(1) = aplikace, kterou hledame/odinstalovavame


Set objArgs = Wscript.Arguments
'  True           - pouze ulo�� v�sledky hled�n�
'  False          - ihned odinstaluje
Dim ToFile: ToFile = True

'  "."            - provede v PC, kde je script spu�t�n
'  "SKDATVxxyyyy" - provede v definovan�m PC
Dim strComputer: strComputer = objArgs(0)
      
'  "vector"       - ��st n�zvu aplikace, kter� m� b�t nalezena
Dim AppToSearch: AppToSearch = objArgs(1)
      
      
      
'-------------------------------------------------------------------------------
'Zde Ji� NEM�NIT!
Const HKEY_LOCAL_MACHINE = &H80000002   
sRegPath = "Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\"
      
If ToFile = True Then                                            
  GetTmpPath  = CreateObject("Scripting.FileSystemObject").GetSpecialFolder(2)                         
  Temp = GetTmpPath & "MSIStrings.csv"
  Set newFileO = CreateObject("Scripting.FileSystemObject")
  Set newFile  = newFileO.CreateTextFile(Temp, True)    
End If

Set cimv2 = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")
Set oService = cimv2.Get("Win32_Service.Name='RemoteRegistry'")
oService.StartService
                                                                                    
Set wShell = CreateObject("WScript.Shell") 
Set oReg=GetObject("winmgmts:{impersonationLevel=impersonate}!\\" & strComputer _
          & "\root\default:StdRegProv")
oReg.EnumKey HKEY_LOCAL_MACHINE, sRegPath, arrSubKeys
      
For Each strAsk In arrSubKeys  
  keyStr = sRegPath & strAsk & "\"
  oReg.GetStringValue HKEY_LOCAL_MACHINE,keyStr,"DisplayName",DisplayName  
  oReg.GetStringValue HKEY_LOCAL_MACHINE,keyStr,"UninstallString",UninstallString  
  If InStr(1, LCase(DisplayName), LCase(AppToSearch)) > 0 Then    
    If ToFile = True Then
      newFile.WriteLine DisplayName & ";" & UninstallString
    Else
      wShell.Run UninstallString & " /silent", 1, True
    End If
  End If 
Next  
      
If ToFile = True Then 
  newFile.Close
  wShell.Run "excel.exe " & Temp, 1, True
End If

        
oService.StopService