using Model.Base.Config;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Component.Config
{
    [BsonIgnoreExtraElements]
    public class HttpConfig : AConfigComponent
    {
        public string Url { get; set; } = "";
        public int AppId { get; set; }
        public string AppKey { get; set; } = "";
        public string ManagerSystemUrl { get; set; } = "";
    }
}
