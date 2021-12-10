using CQRS_Base.CQRS.Commands.Request;
using CQRS_Base.CQRS.Commands.Response;
using CQRS_Base.CQRS.Handlers.CommandHandlers;
using CQRS_Base.CQRS.Handlers.QueryHandlers;
using CQRS_Base.CQRS.Queries.Request;
using CQRS_Base.CQRS.Queries.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region CommandHandlers
        readonly CreateProductCommandHandler _createProductCommandHandler;
        readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        #endregion

        #region QueryHandlers
        readonly GetAllProductQueryHandler _getAllProductQueryHandler;
        readonly GetByIdProductQueryHandler _getByIdProductQueryHandler; 
        #endregion

        public ProductController(
            CreateProductCommandHandler createProductCommandHandler,
            DeleteProductCommandHandler deleteProductCommandHandler,
            GetAllProductQueryHandler getAllProductQueryHandler,
            GetByIdProductQueryHandler getByIdProductQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getAllProductQueryHandler = getAllProductQueryHandler;
            _getByIdProductQueryHandler = getByIdProductQueryHandler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]GetAllProductQueryRequest request)
        {
            List<GetAllProductQueryResponse> allProducts = _getAllProductQueryHandler.GetAllProducts(request);
            return Ok(allProducts);
        }

        [HttpGet("[action]")]
        public IActionResult GetById([FromQuery]GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse product = _getByIdProductQueryHandler.GetByIdProduct(request);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _createProductCommandHandler.CreateProduct(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response = await _deleteProductCommandHandler.DeleteProduct(request);
            return Ok(response);
        }

    }
}
