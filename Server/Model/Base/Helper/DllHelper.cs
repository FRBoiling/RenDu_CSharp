using System.IO;
using System.Reflection;

namespace Model.Base.Helper
{
    public static class DllHelper
    {
        public static Assembly GetHotfixAssembly()
        {
            byte[] dllBytes = File.ReadAllBytes("./Hotfix.dll");
            byte[] pdbBytes = File.ReadAllBytes("./Hotfix.pdb");
            Assembly assembly = Assembly.Load(dllBytes, pdbBytes);
            return assembly;
        }

        public static Assembly GetProtocolAssembly()
        {
            byte[] dllBytes = File.ReadAllBytes("Protocol.dll");
            byte[] pdbBytes = File.ReadAllBytes("Protocol.pdb");
            Assembly assembly = Assembly.Load(dllBytes, pdbBytes);
            return assembly;
        }

    }
}
