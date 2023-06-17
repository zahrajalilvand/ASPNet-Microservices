using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> GetProducts(string Id);
        Task<IEnumerable<Products>> GetByName(string name);
        Task<IEnumerable<Products>> GetByCategory(string categoryName);
        Task CreateProduct(Products products);
        Task<bool> UpdateProduct(Products products);
        Task<bool> DeleteProduct(string id);
    }
}
