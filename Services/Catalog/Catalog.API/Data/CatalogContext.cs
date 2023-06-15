using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Products> Products { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings: ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings: DatabaseName"));
            Products = database.GetCollection<Products>(configuration.GetValue<string>("DatabaseSettings: CollectioName"));
            CatalogContextSeed.DataSeed(Products);
        }
    }
}
