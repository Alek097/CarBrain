using System;
using MongoDB.Bson;

namespace CarBrain.System
{
	public class Position
	{
		public ObjectId Id { get; set; }
		public int X { get; set; }
		public int Y { get; set; }

		public Position (int x, int y)
		{
			this.Id = new ObjectId ();
			this.X = x;
			this.Y = y;
		}
	}
}

