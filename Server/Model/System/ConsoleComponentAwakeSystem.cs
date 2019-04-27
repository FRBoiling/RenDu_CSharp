using Model.Base.RDAttribute;
using Model.Base.System;
using Model.Component;

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
