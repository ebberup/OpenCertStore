using Org.BouncyCastle.Pkcs;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
             GetPrivateKeyFromP12(@"C:\Users\admin\Documents\Visual Studio 2017\Projects\OpenCertStore\borger.p12", "hello world");
        }
        private static void GetPrivateKeyFromP12(string path, string passWord)
        {

            using (StreamReader reader = new StreamReader(path))
            {
                var fs = reader.BaseStream;
                char[] pw = passWord.ToCharArray();
                Pkcs12Store store = new Pkcs12Store(fs, pw);

                foreach (var item in store.Aliases)
                {
                    var cert = store.GetCertificate(item.ToString());
                    Console.WriteLine(item.ToString() +": valid until:"+ cert.Certificate.NotAfter.ToString());
                }
            }
            Console.ReadKey();
        }

    }
}
