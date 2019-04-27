using System;
using System.Threading;
using System.Threading.Tasks;
using Model;
using Model.Base;
using Model.Component;
using Model.Helper;
using Model.Logger;
using Model.System;

namespace App
{


    internal static class Program
    {
        public static int AppId = 1001;

        public static AppType AppType = AppType.Realm;

        public static string ServerIP = "192.168.10.123";


        private static void Main(string[] args)
        {

            // 异步方法全部会回掉到主线程
            SynchronizationContext.SetSynchronizationContext(SingletonSynchronizationContext.Instance);
            Log.Debug($"current thread id {Thread.CurrentThread.ManagedThreadId}");

            try
            {
                Server.EventSystem.Add(DLLType.Model, typeof(Server).Assembly);

                //LogManager.Configuration.Variables["appType"] = $"{AppType}";
                //LogManager.Configuration.Variables["appId"] = $"{AppId}";
                //LogManager.Configuration.Variables["appTypeFormat"] = $"{AppType,-8}";
                //LogManager.Configuration.Variables["appIdFormat"] = $"{AppId:0000}";
                //while (true)
                //{
                //    Log.Trace($"server start.............Trace........... {AppId} {AppType}");
                //    Log.Debug($"server start.............Debug........... {AppId} {AppType}");
                //    Log.Info($"server start.............Info............ {AppId} {AppType}");
                //    Log.Warn($"server start.............Warn........... {AppId} {AppType}");
                //    Log.Error($"server start.............Error........... {AppId} {AppType}");
                //    Log.Fatal($"server start.............Fatal........... {AppId} {AppType}");
                //}

                Server.Context.AddComponent<ConsoleComponent>();

                while (true)
                {
                    try
                    {
                        Thread.Sleep(1);
                        SingletonSynchronizationContext.Instance.Update();
                        Server.EventSystem.Update();
                    }
                    catch (Exception e)
                    {
                        Log.Error(e);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
    }
}
