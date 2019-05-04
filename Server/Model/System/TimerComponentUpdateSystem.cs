using Model.Base.RDAttribute;
using Model.Base.System;
using Model.Component;

namespace Model.System
{
    [ObjectSystem]
    public class TimerComponentUpdateSystem : AUpdateSystem<TimerComponent>
    {
        public override void Update(TimerComponent self)
        {
            self.Update();
        }
    }
}
