using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarBrain.Data
{
	public class DataBase<TModel>
	{
		private IMongoCollection<TModel> collection { get; set; }

		public DataBase (string dbName, string collectionName)
		{
			MongoClient client = new MongoClient ("mongodb://localhost:27017");
			this.collection = client.GetDatabase (dbName).GetCollection<TModel>(collectionName);
		}

		public void Insert(TModel model)
		{
			this.collection.InsertOne (model);
		}

		public void Insert(IEnumerable<TModel> models)
		{
			this.collection.InsertMany (models);
		}

		public async void InsertAsync(IEnumerable<TModel> models)
		{
			await this.collection.InsertManyAsync (models);
		}

		public async void InsertAsync(TModel model)
		{
			await this.collection.InsertOneAsync (model);
		}
	}
}

