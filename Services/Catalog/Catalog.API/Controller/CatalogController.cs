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

        #region Get Product By Category
        [HttpGet("[action/{category}]")]
        [ProducesResponseType(typeof(IEnumerator<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetByCategory(string categoryName)
        {
            var product = await _productRepository.GetByCategory(categoryName);

            return Ok(product);
        }
        #endregion

        #region Get Product By Name
        [HttpGet("[action/{Name}]")]
        [ProducesResponseType(typeof(IEnumerator<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetByName(string name)
        {
            var product = await _productRepository.GetByName(name);

            return Ok(product);
        }
        #endregion

        #region Create Product
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerator<Products>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Products>> CreateProduct([FromBody] Products products)
        {
            await _productRepository.CreateProduct(products);

            return CreatedAtRoute("GetProducts", new { id = products.Id }, products);
        }
        #endregion

        #region Update Product
        [HttpPut]
        [ProducesResponseType(typeof(IEnumerator<Products>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Products products)
        {
            return Ok(await _productRepository.UpdateProduct(products));
        }
        #endregion

        #region Delete Product
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(IEnumerator<Products>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            return Ok(await _productRepository.DeleteProduct(id));
        }
        #endregion
    }
}
