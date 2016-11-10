using System;
using MongoDB.Bson;

namespace CarBrain.System.Models
{
	public class Icon
	{
		public ObjectId Id { get; set; }
		public Position Position { get; set; }
		public byte[] Img { get; set; }
		public string AppPath { get; set; }
		public string Text { get; set; }
	}
}

