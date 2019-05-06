using Model.Base.RDAttribute;
using Model.Base.System;
using Model.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Message
{
    [ObjectSystem]
    public class NetInnerComponentAwakeSystem : AAwakeSystem<NetInnerComponent>
    {
        public override void Awake(NetInnerComponent self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class NetInnerComponentAwake1System : AAwakeSystem<NetInnerComponent, string>
    {
        public override void Awake(NetInnerComponent self, string a)
        {
            self.Awake(a);
        }
    }

}
