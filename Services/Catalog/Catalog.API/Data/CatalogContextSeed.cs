using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void DataSeed(IMongoCollection<Products> ProductCollection) 
        { 
            bool existData = ProductCollection.Find(p => true).Any();
            if (!existData) {
                ProductCollection.InsertManyAsync(GetProductData());
            }
        }

        private static IEnumerable<Products> GetProductData()
        {
            return new List<Products>()
            {
                new Products()
                {
                    Id = "602d2149e773fa2a3990b47f5",
                    Name = "IPhone x",
                    Summary = "Description",
                    Description = "Description",
                    imageFile = "Product-1.png",
                    Price = 100.00M,
                    Category = "Category"
                },
                new Products()
                {
                    Id = "602d2149e773fa2a3990b47f6",
                    Name = "IPhone 10",
                    Summary = "Description",
                    Description = "Description",
                    imageFile = "Product-1.png",
                    Price = 150.00M,
                    Category = "Category"
                },
                new Products()
                {
                    Id = "602d2149e773fa2a3990b47f7",
                    Name = "IPhone 11",
                    Summary = "Description",
                    Description = "Description",
                    imageFile = "Product-1.png",
                    Price = 400.00M,
                    Category = "Category"
                },
                new Products()
                {
                    Id = "602d2149e773fa2a3990b47f8",
                    Name = "IPhone 12",
                    Summary = "Description",
                    Description = "Description",
                    imageFile = "Product-1.png",
                    Price = 500.00M,
                    Category = "Category"
                }
            };
        }
    }
}
