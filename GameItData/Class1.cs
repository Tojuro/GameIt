using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameItData
{
    public class Meta
    {
        public Type Type { get; set; }
        public Dictionary<string, string> Tags { get; set; }
    }

    public interface IBlobject
    {
        Guid Id { get; set; }
        Meta Meta { get; set; }
        string Value { get; set; }
    }

    public class Blobject : IBlobject
    {
        public Guid Id { get; set; }
        public Meta Meta { get; set; }
        public string Value { get; set; }
    }

    public class Repository<T> where T:IBlobject
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected static IMongoCollection<T> _collection;

        public Repository(string database, string collection)
        {
            _client = new MongoClient();
            _database = _client.GetDatabase(database);
            _collection = _database.GetCollection<T>(collection);
        }

        public Guid Put<T>(string collection, Blobject blobject)
        {
            return Guid.NewGuid();
        }

        public async Task<T> GetOne(Guid guid)
        {
            var results = await Get(guid);
            return results.FirstOrDefault<T>();
        }

        public async Task<IAsyncCursor<T>> Get(Guid guid)
        {
            return await _collection.FindAsync<T>(_ => _.Id == guid);
        }

        public async Task<IAsyncCursor<T>> Get(string key, string value)
        {
            return await _collection.FindAsync<T>(_ => _.Meta.Tags.ContainsKey(key) && _.Meta.Tags[key].Equals(value));
        }

        public List<Blobject> Get(string key, Guid guid)
        {
            return new List<Blobject>();
        }

    }
}
