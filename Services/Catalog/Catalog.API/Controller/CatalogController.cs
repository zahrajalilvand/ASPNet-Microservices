using Catalog.API.Data;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        #region Constructor
        private readonly ICatalogContext _catalogContext;
        private readonly IProductRepository _productRepository;

        public CatalogController()
        {
            
        }
        #endregion
    }
}
