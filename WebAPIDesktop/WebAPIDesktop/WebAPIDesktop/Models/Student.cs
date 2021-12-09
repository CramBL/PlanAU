using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIDesktop.Models {
	public class Student
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; }
		public string auId { get; set; }
		public string password { get; set; }
		public string email { get; set; }
		public List<ToDo> toDos { get; set; }
		public List<string> courses { get; set; }
	}
}