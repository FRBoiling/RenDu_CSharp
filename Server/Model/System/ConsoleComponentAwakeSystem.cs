using Model.Component;
using Model.RDAttribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.System
{
	[ObjectSystem]
    public class ConsoleComponentAwakeSystem : AStartSystem<ConsoleComponent>
    {
        public override void Start(ConsoleComponent self)
        {
            self.Start().Coroutine();
        }
    }
}
