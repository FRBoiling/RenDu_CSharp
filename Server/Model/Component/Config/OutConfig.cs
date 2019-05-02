using Model.Base.Config;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Component.Config
{
	[BsonIgnoreExtraElements]
    public class OuterConfig : AConfigComponent
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
    }
}
