using Model.Base.RDAttribute;
using Model.Base.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Message.Network
{
    [ObjectSystem]
    public class NetOuterComponentAwakeSystem : AAwakeSystem<NetOuterComponent>
    {
        public override void Awake(NetOuterComponent self)
        {
            self.Awake(self.Protocol);
            self.MessagePacker = new ProtobufPacker();
            self.MessageDispatcher = new OuterMessageDispatcher();
        }
    }

    [ObjectSystem]
    public class NetOuterComponentAwake1System :AAwakeSystem<NetOuterComponent, string>
    {
        public override void Awake(NetOuterComponent self, string address)
        {
            self.Awake(self.Protocol, address);
            self.MessagePacker = new ProtobufPacker();
            self.MessageDispatcher = new OuterMessageDispatcher();
        }
    }

    [ObjectSystem]
    public class NetOuterComponentLoadSystem : ALoadSystem<NetOuterComponent>
    {
        public override void Load(NetOuterComponent self)
        {
            self.MessagePacker = new ProtobufPacker();
            self.MessageDispatcher = new OuterMessageDispatcher();
        }
    }

    [ObjectSystem]
    public class NetOuterComponentUpdateSystem : AUpdateSystem<NetOuterComponent>
    {
        public override void Update(NetOuterComponent self)
        {
            self.Update();
        }
    }
}
