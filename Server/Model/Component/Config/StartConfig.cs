using Model.Base.Component;

namespace Model.Component.Config
{
    public class StartConfig : BaseEntity
    {
        public int AppId { get; set; }

        //[BsonRepresentation(BsonType.String)]
        public AppType AppType { get; set; }

        public string ServerIP { get; set; }
    }
}
