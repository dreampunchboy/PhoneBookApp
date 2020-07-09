using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApp.Models.Phone
{
    public class PhoneBook
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PhoneBookEntry> Entries { get; set; }
    }
}
