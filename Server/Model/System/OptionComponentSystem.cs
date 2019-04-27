using Model.Base.RDAttribute;
using Model.Base.System;
using Model.Component;

namespace Model.System
{
    [ObjectSystem]
    public class OptionComponentSystem : AAwakeSystem<OptionComponent, string[]>
    {
        public override void Awake(OptionComponent self, string[] a)
        {
            self.Awake(a);
        }
    }

}
