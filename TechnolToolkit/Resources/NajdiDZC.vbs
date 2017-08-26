toFind=inputbox("Zadejte pøímení (bez háèkù a èárek) nebo DZCxxxx")
'inputbox "Nalezeno:",, GetUserPath(toFind)
msgbox GetUserPath(toFind),,"Nalezené údaje:"


function GetUserPath(username)
  Const ADS_SCOPE_SUBTREE = 3
  Set objConnection = CreateObject("ADODB.Connection")
  Set objCommand =   CreateObject("ADODB.Command")
  objConnection.Provider = "ADsDSOObject"
  objConnection.Open "Active Directory Provider"
  Set objCOmmand.ActiveConnection = objConnection
  'objCommand.CommandText = "Select Name from 'LDAP://DC=skoda,DC=vwg' Where samAccountName='" & username   & "'"
  objCommand.CommandText = "Select name, samAccountName  from 'LDAP://DC=skoda,DC=vwg' Where sn='" & username   & "' or samAccountName='" & username & "'"   
 '' objCommand.Properties("Page Size") = 1000
 '' objCommand.Properties("Searchscope") = ADS_SCOPE_SUBTREE 
  Set objRecordSet = objCommand.Execute

on error resume next
  objRecordSet.MoveFirst
  'odpoved="NENALEZENO !!!"
  Do Until objRecordSet.EOF
     FullName=objRecordSet.Fields("name").Value
     
     DZC = objRecordSet.Fields("samAccountName").Value  
     if DZC<>"" then
     'dzc= "->" & ucase(DZC) & "<-"
     end if
       odpoved=odpoved &  dzc & " = " & FullName & chr(13) & chr(10)    
       objRecordSet.MoveNext
  Loop
 
  Set objRecordSet = nothing
  Set objCOmmand.ActiveConnection = nothing
  Set objCommand = nothing
  Set objConnection = nothing
  GetUserPath=odpoved
end function
