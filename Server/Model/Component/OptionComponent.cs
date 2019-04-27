using System;
using CommandLine;
using Model.Base.Component;

namespace Model.Component
{
    public class OptionComponent : AComponent
    {
        public Options Options { get; set; }

        public void Awake(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithNotParsed(error => throw new Exception($"命令行格式错误!"))
                .WithParsed(options => { Options = options; });
        }
    }
}
