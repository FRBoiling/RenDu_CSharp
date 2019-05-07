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

    [ObjectSystem]
    public class NetInnerComponentLoadSystem : ALoadSystem<NetInnerComponent>
    {
        public override void Load(NetInnerComponent self)
        {
            self.MessagePacker = new MongoPacker();
            self.MessageDispatcher = new InnerMessageDispatcher();
        }
    }

    [ObjectSystem]
    public class NetInnerComponentUpdateSystem : AUpdateSystem<NetInnerComponent>
    {
        public override void Update(NetInnerComponent self)
        {
            self.Update();
        }
    }

}
