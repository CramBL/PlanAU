using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DBApi.Models {
	public class Student
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string auId { get; set; }
		public string password { get; set; }
		public string email { get; set; }

		public List<string> courses { get; set; }
		public List<ToDo> toDos { get; set; }
	}
}