using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Models
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
