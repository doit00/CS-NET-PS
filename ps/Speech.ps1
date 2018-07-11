$asm =  [System.Reflection.Assembly]::LoadWithPartialName("System.Speech")
$synt = New-Object -TypeName System.Speech.Synthesis.SpeechSynthesizer
$synt.Rate = -3
$synt.Speak("Lepsze niż beep");
