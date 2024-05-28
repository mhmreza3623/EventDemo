using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedKernel.Common.MongoDb
{
    public class CollectionBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
