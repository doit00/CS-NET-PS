$d = "01/02/10"

$enUs = [System.Globalization.CultureInfo]::GetCultureInfo("en-US")
$plPl = "pl-PL" -as [Globalization.CultureInfo]

$d.ToDateTime($enUs)
$d.ToDateTime($plPl)

$d -as [DateTime] #