#1 simple array (untyped)

$array = @(1,1)

#2 Array List collection (untyped)
[System.Collections.ArrayList]$arrayList = @(1,1)
$arrayList.GetType().FullName

#3 Generic List Collection (typed)
[System.Collections.Generic.List[int]]$list = @(1,1)
$list.GetType().FullName

#4 Generic Dictionary (typed)
$d  = New-Object 'system.collections.generic.SortedDictionary[int,string]'
$d.GetType().FullName
$d.Add(1,"abc")
$d[1]

#5 Specialized dictionary (untyped)
$o = [ordered]@{1='a';2='b'} #System.Collections.Specialized.OrderedDictionary




