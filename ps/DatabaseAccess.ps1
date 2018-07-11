$cnn = New-Object System.Data.SqlClient.SqlConnection

#$cnn2 = [System.Data.SqlClient.SqlConnection]::new()
$cnn.ConnectionString = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demo;Integrated Security=True'

$cmd = new-object System.Data.SqlClient.SqlCommand

$cmd.Connection = $cnn
$cmd.CommandText = "Select * from Logs"

$cnn.Open()
[System.Data.SqlClient.SqlDataReader]$rdr =  $cmd.ExecuteReader()
while ($rdr.Read())
{
    $dateField = $rdr.GetDateTime(2);
    $intField = $rdr.GetInt32(0);
    $strField = $rdr.GetString(1);
    Write-Host "$intField $strField $dateField"
        
}

$cnn.Close()

