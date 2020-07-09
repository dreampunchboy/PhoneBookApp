using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Models.Phone
{
    public class PhoneBookEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PhoneBookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
