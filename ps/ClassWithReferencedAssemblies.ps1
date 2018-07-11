$Assem = (
    "Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" ,
    "Microsoft.SharePoint.Publishing, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c"
    )

$Source = @"
using Microsoft.SharePoint.Publishing.Administration;
using System;

namespace StefanG.Tools
{
    public static class CDRemoteTimeout 
    {
        public static void Get()
        {
            ContentDeploymentConfiguration cdconfig = ContentDeploymentConfiguration.GetInstance();
            Console.WriteLine("Remote Timeout: "+cdconfig.RemoteTimeout);
        } 
         
        public static void Set(int seconds)
        {
            ContentDeploymentConfiguration cdconfig = ContentDeploymentConfiguration.GetInstance();
            cdconfig.RemoteTimeout = seconds;
            cdconfig.Update();
        }
    }
}
"@

Add-Type -ReferencedAssemblies $Assem -TypeDefinition $Source -Language CSharp 
