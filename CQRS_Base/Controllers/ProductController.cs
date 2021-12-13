using CQRS_Base.CQRS.Commands.Request;
using CQRS_Base.CQRS.Commands.Response;
using CQRS_Base.CQRS.Handlers.CommandHandlers;
using CQRS_Base.CQRS.Handlers.QueryHandlers;
using CQRS_Base.CQRS.Queries.Request;
using CQRS_Base.CQRS.Queries.Response;
using MediatR;
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
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery]GetByIdProductQueryRequest requestModel)
        {
            GetByIdProductQueryResponse product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

    }
}
