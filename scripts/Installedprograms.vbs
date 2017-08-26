'Sets up needed resources/variables/constants 
Set wmiServices = GetObject("winmgmts:root/default") 
Set wmiSink = WScript.CreateObject("WbemScripting.SWbemSink", "SINK_") 
Set objFSO = CreateObject("Scripting.FileSystemObject") 

Set objShell = CreateObject("WScript.Shell")


StrFileName = "C:\Temp\InstalledPrograms.log"
StrCompareFile = "C:\Uninstall.cmp" 
Const ForWriting = 2, ForReading = 1 
Const HKEY_LOCAL_MACHINE = &H80000002 



WScript.Echo StrFileName
Set objShell = nothing
 
'objFSO.DeleteFile(StrFileName)  

if Not objFSO.FolderExists("C:\Temp") Then
objFSO.CreateFolder("C:\Temp")
End If


if Not objFSO.FileExists(StrFileName) Then 
  Set objTextFile = objFSO.CreateTextFile(StrFileName) 
  Set objTextFile = Nothing 
 End If 

Set objTextFile = objFSO.OpenTextFile(StrFileName,ForWriting) 
  OutToFile(objTextFile) 
  objTextFile.Close
  
 
'Sub routine that outputs the registry 
Sub OutToFile(objTxt) 
 
 Set oReg=GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv") 
 strKeyPath = "Software\Microsoft\Windows\CurrentVersion\Uninstall" 
 oReg.EnumKey HKEY_LOCAL_MACHINE, strKeyPath, arrValueNames, arrValueTypes 


 Set outputLines = CreateObject("System.Collections.ArrayList")
  
 For i=0 To UBound(arrValueNames) 
     StrText = arrValueNames(i)
          
     oReg.GetStringValue HKEY_LOCAL_MACHINE,strKeyPath & "\" & arrValueNames(i), "DisplayName",strName 
     oReg.GetStringValue HKEY_LOCAL_MACHINE,strKeyPath & "\" & arrValueNames(i), "DisplayVersion",strVersion 

     Name=""

     If (VarType(StrName)<>vbString) Then
        Name=arrValueNames(i)
     Else
        Name=StrName
     End If

     StrText = Name & ";" & StrVersion 
     If (VarType(StrName)=vbString) And (StrName<>"") And (Left(arrValueNames(i),2)<>"KB") And (Mid(arrValueNames(i),40,2)<>"KB") And (InStr(Name,"(KB")=0) And (InStr(Name,"MUI")=0) And (InStr(Name,"Service Pack")=0) And (InStr(Name,"Office Proof")=0) And (InStr(Name,"Update")=0) Then
        outputLines.Add(StrText) 
     End If
     
 Next 

outputLines.Sort()
LastLine=""
     For Each outputLine in outputLines
        If (LastLine<>outputLine) Then
           objTxt.WriteLine(outputLine)           
        End If  
        LastLine=outputLine
     Next
End Sub 