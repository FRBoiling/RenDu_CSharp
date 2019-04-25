using Model.RDAttribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Event
{
    public class EventAttribute : BaseAttribute
    {
        public string Type { get; }

        public EventAttribute(string type)
        {
            this.Type = type;
        }
    }
}
