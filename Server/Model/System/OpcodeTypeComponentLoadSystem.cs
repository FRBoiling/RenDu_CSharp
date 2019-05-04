using Model.Base.RDAttribute;
using Model.Base.System;
using Model.Component;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.System
{
    [ObjectSystem]
    public class OpcodeTypeComponentLoadSystem : ALoadSystem<OpcodeTypeComponent>
    {
        public override void Load(OpcodeTypeComponent self)
        {
            self.Load();
        }
    }

}
