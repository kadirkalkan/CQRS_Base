using CQRS_Base.CQRS.Commands.Request;
using CQRS_Base.CQRS.Commands.Response;
using CQRS_Base.Models.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Base.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        readonly DatabaseContext _context;
        public DeleteProductCommandHandler([FromServices] DatabaseContext context)
        {
            _context = context;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var data = _context.Products.FirstOrDefault(x => x.Id.Equals(request.Id));
            _context.Products.Remove(data);
            await _context.SaveChangesAsync();

            return new DeleteProductCommandResponse()
            {
                IsSuccess = true
            };
        }
    }
}
