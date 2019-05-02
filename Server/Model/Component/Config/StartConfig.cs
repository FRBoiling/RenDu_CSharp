using Model.Base.Component;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Component.Config
{
    public class StartConfig : BaseEntity
    {
        public int AppId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public AppType AppType { get; set; }

        public string ServerIP { get; set; }
    }
}
