using Model.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.System
{
    public class ConsoleComponentAwakeSystem : AStartSystem<ConsoleComponent>
    {
        public override void Start(ConsoleComponent self)
        {
            self.Start().Coroutine();
        }
    }
}
