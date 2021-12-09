using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIDesktop.Models
{
    public class ToDo
    {
        public string title { get; set; }
        public string description { get; set; }

        [BsonElement]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime lastDate { get; set; }
    }
}
