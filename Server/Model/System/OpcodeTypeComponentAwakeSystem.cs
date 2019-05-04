using Model.Base.RDAttribute;
using Model.Base.System;
using Model.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.System
{
    [ObjectSystem]
    public class OpcodeTypeComponentAwakeSystem : AAwakeSystem<OpcodeTypeComponent>
    {
        public override void Awake(OpcodeTypeComponent self)
        {
            self.Load();
        }
    }
}
