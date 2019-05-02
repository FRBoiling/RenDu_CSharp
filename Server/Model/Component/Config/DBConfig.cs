using Model.Base.Config;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Component.Config
{
    [BsonIgnoreExtraElements]
    public class DBConfig : AConfigComponent
    {
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
    }
}
