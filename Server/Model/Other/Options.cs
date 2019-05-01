using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Options
    {
		[Option("appId", Required = false, Default = 1)]
        public int AppId { get; set; }

		[Option("appType", Required = false, Default = AppType.Manager)]
        // 没啥用，主要是在查看进程信息能区分每个app.exe的类型
        public AppType AppType { get; set; }

		[Option("config", Required = false, Default = "../Config/StartConfig/LocalAllServer.txt")]
        public string Config { get; set; }
    }
}
