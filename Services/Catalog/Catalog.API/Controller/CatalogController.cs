using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        #region Constructor
        private readonly ILogger<CatalogController> _logger;
        private readonly IProductRepository _productRepository;

        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
        #endregion

        #region Get Product
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerator<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            var product = await _productRepository.GetProducts();
            return Ok(product);
        }
        #endregion

        #region Get Product By Id
        [HttpGet("{id:length(24)}", Name ="GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerator<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts(string Id)
        {
            var product = await _productRepository.GetProducts(Id);

            if (product == null)
            {
                _logger.LogError($"Product Id: {Id} is not found.");
                return NotFound();
            }

            return Ok(product);
        }
        #endregion

    }
}
