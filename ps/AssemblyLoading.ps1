$dllPath = 'c:\users\administrator\source\repos\Tools\Tools\bin\Debug\Tools.dll'
$asm =[System.Reflection.Assembly]::LoadFile($dllPath)
$asm

$tools = New-Object -TypeName Tools.ContextTools
$tools.UserName