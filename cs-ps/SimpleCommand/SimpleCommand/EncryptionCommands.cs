using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommand
{
    class EncryptionCommands
    {
        public static void DecryptData(string password, string saltValue, string sourcePath, string destinationPath)
        {
            var encryptedSource = File.ReadAllBytes(sourcePath);

            AesManaged alg;
            byte[] key, iv;
            InitAlgorithm(password, saltValue, out alg, out key, out iv);
            var encryptor = alg.CreateDecryptor(key, iv);
            var target = new MemoryStream();
            var source = encryptedSource;
            var cs = new CryptoStream(target, encryptor, CryptoStreamMode.Write);
            cs.Write(source, 0, source.Length);
            cs.FlushFinalBlock();
            var encrypted = target.ToArray();
            var output = Encoding.Unicode.GetString(encrypted);

            File.WriteAllText(destinationPath, output);
        }

        public static void EncryptData(string password, string saltValue, string sourcePath, string destinationPath)
        {
            AesManaged alg;
            byte[] key, iv;
            InitAlgorithm(password, saltValue, out alg, out key, out iv);

            var encryptor = alg.CreateEncryptor(key, iv);
            var target = new MemoryStream();
            var source = Encoding.Unicode.GetBytes(File.ReadAllText(sourcePath));
            var cs = new CryptoStream(target, encryptor, CryptoStreamMode.Write);
            cs.Write(source, 0, source.Length);
            cs.FlushFinalBlock();
            var encrypted = target.ToArray();
          
            File.WriteAllBytes(destinationPath, encrypted);
        }

        private static void InitAlgorithm(string password, string saltValue, out AesManaged alg, out byte[] key, out byte[] iv)
        {
            alg = new AesManaged();
            var salt = Encoding.Unicode.GetBytes(saltValue);
            var hash = new Rfc2898DeriveBytes(password, salt);
            key = hash.GetBytes(alg.KeySize / 8);
            iv = hash.GetBytes(alg.BlockSize / 8);
        }
        
        public string FromSecureString(SecureString str)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(str);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }

        }
    }

    [Cmdlet(VerbsCommon.Set,"EncryptedFile")]
    public class EncryptCommand:Cmdlet
    {
        [Parameter]
        public string Password { get; set; }
        [Parameter]
        public string Salt { get; set; }
        [Parameter]
        public string SourcePath { get; set; }
        [Parameter]
        public string DestinationPath { get; set; }

        protected override void EndProcessing()
        {
            EncryptionCommands.EncryptData(Password, Salt, SourcePath, DestinationPath);
            WriteObject("Encryption completed");

        }

    }

    [Cmdlet(VerbsCommon.Get, "DecryptedFile")]
    public class DecryptCommand : Cmdlet
    {
        [Parameter]
        public string Password { get; set; }
        [Parameter]
        public string Salt { get; set; }
        [Parameter]
        public string SourcePath { get; set; }
        [Parameter]
        public string DestinationPath { get; set; }

        protected override void EndProcessing()
        {
            EncryptionCommands.DecryptData(Password, Salt, SourcePath, DestinationPath);
            WriteObject("Decryption completed");

        }

    }


}
