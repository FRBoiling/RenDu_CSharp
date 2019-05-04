using System;
using System.Threading;
using Model;
using Model.Base;
using Model.Base.Helper;
using Model.Base.Logger;
using Model.Component;
using Model.Component.Config;
using NLog;

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
        
            try
            {
                Log.Debug($"current thread id {Thread.CurrentThread.ManagedThreadId}");
                Server.EventSystem.Add(DLLType.Model, typeof(Server).Assembly);
                //Server.EventSystem.Add(DLLType.Hotfix, DllHelper.GetHotfixAssembly());

                Options options = Server.Context.AddComponent<OptionComponent, string[]>(args).Options;
                StartConfig startConfig = Server.Context.AddComponent<StartConfigComponent, string, int>(options.Config, options.AppId).StartConfig;

                if (!options.AppType.Is(startConfig.AppType))
                {
                    Log.Error("命令行参数apptype与配置不一致");
                    return;
                }

                IdGeneraterHelper.AppId = options.AppId;

                LogManager.Configuration.Variables["appType"] = $"{startConfig.AppType}";
                LogManager.Configuration.Variables["appId"] = $"{startConfig.AppId}";
                LogManager.Configuration.Variables["appTypeFormat"] = $"{startConfig.AppType,-8}";
                LogManager.Configuration.Variables["appIdFormat"] = $"{startConfig.AppId:0000}";

                Log.Info($"server start........................ {startConfig.AppId} {startConfig.AppType}");


                Server.Context.AddComponent<TimerComponent>();
                Server.Context.AddComponent<OpcodeTypeComponent>();
                Server.Context.AddComponent<MessageDispatcherComponent>();


                // 根据不同的AppType添加不同的组件
                OuterConfig outerConfig = startConfig.GetComponent<OuterConfig>();
                InnerConfig innerConfig = startConfig.GetComponent<InnerConfig>();

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
