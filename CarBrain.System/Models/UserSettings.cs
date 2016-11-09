using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace CarBrain.System.Models
{
	public class UserSettings
	{
		public ObjectId Id { get; set; }
		public byte[] Background { get; set; }
		public List<Icon> Icons { get; set; }
	}
}

