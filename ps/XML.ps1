$xmlText = @'
<?xml version="1.0" encoding="utf-8"?>
<Order>
  <Details ID="1">
    <Line>OrderLine1</Line>
  </Details>
</Order>
'@
[xml]$doc = $xmlText
