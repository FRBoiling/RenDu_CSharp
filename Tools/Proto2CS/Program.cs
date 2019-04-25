using Model.Helper;
using System;
using System.Runtime.InteropServices;

namespace Proto2CS
{
    class Program
    {
        static void Main(string[] args)
        {
            string protoc = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                protoc = "protoc.exe";
            }
            else
            {
                protoc = "protoc";
            }
            protoc = ConstData.PROTOC_PATH + protoc;
            ProcessHelper.Run(protoc, "--csharp_out=\"../../Message/\" --proto_path=\""+ConstData.PROTO_PATH+"\" OuterMessage.proto", waitExit: true);


            Console.WriteLine("Hello World!");
        }
    }
}
