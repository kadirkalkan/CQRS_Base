using CQRS_Base.CQRS.Commands.Request;
using CQRS_Base.CQRS.Commands.Response;
using CQRS_Base.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Base.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler
    {
        readonly DatabaseContext _context;
        public DeleteProductCommandHandler([FromServices] DatabaseContext context)
        {
            _context = context;
        }


        public async Task<DeleteProductCommandResponse> DeleteProduct(DeleteProductCommandRequest request)
        {
            var data = _context.Products.FirstOrDefault(x => x.Id.Equals(request.Id));
            _context.Products.Remove(data);
            await _context.SaveChangesAsync();

            return new DeleteProductCommandResponse() { 
                IsSuccess = true 
            };
        }
    }
}
