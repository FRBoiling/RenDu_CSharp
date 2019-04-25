using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Options
    {
        public int AppId { get; set; }

        // 没啥用，主要是在查看进程信息能区分每个app.exe的类型
        public AppType AppType { get; set; }

        public string Config { get; set; }
    }
}
