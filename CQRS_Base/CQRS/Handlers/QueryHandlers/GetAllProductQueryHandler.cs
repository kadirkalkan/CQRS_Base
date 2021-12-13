using CQRS_Base.CQRS.Queries.Request;
using CQRS_Base.CQRS.Queries.Response;
using CQRS_Base.Models.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Base.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        readonly DatabaseContext _context;
        public GetAllProductQueryHandler([FromServices] DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            return _context.Products.Select(x => new GetAllProductQueryResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                CreateTime = x.CreateTime
            }).ToList();
        }
    }
}
