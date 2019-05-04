using Model.Base.Async;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Base.Time
{
  
        public struct RDTimer
        {
            public long Id { get; set; }
            public long Time { get; set; }
            public RDTaskCompletionSource tcs;
        }
    
}
