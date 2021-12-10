using CQRS_Base.CQRS.Commands.Request;
using CQRS_Base.CQRS.Commands.Response;
using CQRS_Base.Models.Data;
using CQRS_Base.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Base.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler
    {
        readonly DatabaseContext _context;
        public CreateProductCommandHandler([FromServices] DatabaseContext context)
        {
            _context = context;
        }
        public async Task<CreateProductCommandResponse> CreateProduct(CreateProductCommandRequest request)
        {
            var id = Guid.NewGuid();
            _context.Products.Add(new Product()
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity
            });
            await _context.SaveChangesAsync();
            return new CreateProductCommandResponse()
            {
                IsSuccess = true,
                ProductId = id
            };
        }
    }
}
