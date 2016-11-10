using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarBrain.Data
{
	public class DataBase<TModel>
	{
		private IMongoCollection<TModel> collection { get; set; }
		private const string connectionString = "mongodb://localhost:27017";

		public DataBase (string dbName, string collectionName)
		{
			MongoClient client = new MongoClient (connectionString);
			this.collection = client.GetDatabase (dbName).GetCollection<TModel>(collectionName);
		}
		#region insert
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
		#endregion

		#region Get
		public IEnumerable<TModel> Get(Expression<Func<TModel,bool>> filter)
		{
			IFindFluent<TModel, TModel> fluent = this.collection.Find (filter);

			return fluent.ToList ();
		}
		public IEnumerable<TModel> Get()
		{
			return this.collection.Find ((TModel) => true).ToList();
		}

		public async Task<IEnumerable<TModel>> GetAsync()
		{
			using (IAsyncCursor<TModel> cursor = await this.collection.FindAsync ((TModel) => true)) 
			{
				return cursor.ToList ();
			}
		}

		public async Task<IEnumerable<TModel>> GetAsync(Expression<Func<TModel,bool>> filter)
		{
			using (IAsyncCursor<TModel> cursor = await this.collection.FindAsync (filter) )
			{
				return cursor.ToList ();
			}
		}
		#endregion

		#region update
		public void Replace(Expression<Func<TModel,bool>> filter, TModel model)
		{
			this.collection.ReplaceOne (filter, model);
		}

		public async void ReplaceAsync(Expression<Func<TModel,bool>> filter, TModel model)
		{
			await this.collection.ReplaceOneAsync (filter, model);
		}
		#endregion

		#region remove
		public void Remove(Expression<Func<TModel,bool>> filter)
		{
			this.collection.DeleteOne (filter);
		}
		public async void RemoveAsync(Expression<Func<TModel,bool>> filter)
		{
			await this.collection.DeleteOneAsync (filter);
		}
		#endregion

		public static bool Exsist(string dbName)
		{
			MongoServer server = new MongoClient (connectionString).GetServer ();

			IEnumerable<string> dataBases = server.GetDatabaseNames ();

			return dataBases.Contains (dbName);
		}
	}
}
	