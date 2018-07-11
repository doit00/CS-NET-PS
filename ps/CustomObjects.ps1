"" | gm -MemberType *Property


$ht = @{
Count = 1
Data = "abc"
}

$myObj =     New-Object -Property $ht -TypeName PSObject
$myCustObj = New-Object -Property $ht -TypeName PSCustomObject
$myObj.GetType().FullName #output depends on PS Version
$myCustObj.GetType().FullName