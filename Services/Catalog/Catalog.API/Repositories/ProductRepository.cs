using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
            
        }
        public async Task CreateProduct(Products products)
        {
            await _context.Products.InsertOneAsync(products);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p => p.Id, id);
            var deleteResult = await _context.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Products>> GetByCategory(string categoryName)
        {
            FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p=> p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetByName(string name)
        {
            FilterDefinition<Products> filters = 
                Builders<Products>.Filter.Eq(p=> p.Name, name);
            return await _context.Products.Find(filters).ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<Products> GetProducts(string Id)
        {
            return await _context.Products.Find(p => p.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProduct(Products products)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(filter: p => p.Id == products.Id, products);
            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
                 
        }
    }
}
