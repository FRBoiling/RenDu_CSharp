using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Base.Component
{
    [BsonIgnoreExtraElements]
    public abstract class AComponentWithId : AComponent
    {
        [BsonIgnoreIfDefault]
        [BsonDefaultValue(0L)]
        [BsonElement]
        [BsonId]
        public long Id { get; set; }

        protected AComponentWithId()
        {
            this.Id = this.InstanceId;
        }

        protected AComponentWithId(long id)
        {
            this.Id = id;
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();
        }
    }
}
