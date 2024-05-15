using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Core.MongoDb
{
    public class MongoBaseEntity
    {
        public MongoBaseEntity()
        {
            CreateTime = DateTime.Now;
            Id = ObjectId.GenerateNewId().ToString();
        }


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
