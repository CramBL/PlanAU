using System;
using System.ComponentModel.DataAnnotations;

namespace DBApi.Models {
	public class Student
	{
		[Key]
		public string AU_ID { get; set; }
		public string PASSWORD { get; set; }
		public string EMAIL { get; set; }
	}
}