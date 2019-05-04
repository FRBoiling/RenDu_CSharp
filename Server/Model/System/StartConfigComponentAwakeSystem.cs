using Model.Base.RDAttribute;
using Model.Base.System;
using Model.Component.Config;

namespace Model.System
{
    [ObjectSystem]
    public class StartConfigComponentAwakeSystem : AAwakeSystem<StartConfigComponent, string, int>
    {
        public override void Awake(StartConfigComponent self, string a, int b)
        {
            self.Awake(a, b);
        }
    }
}
