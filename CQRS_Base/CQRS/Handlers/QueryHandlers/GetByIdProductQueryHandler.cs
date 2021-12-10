using CQRS_Base.CQRS.Queries.Request;
using CQRS_Base.CQRS.Queries.Response;
using CQRS_Base.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Base.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler
    {
        readonly DatabaseContext _context;
        public GetByIdProductQueryHandler([FromServices] DatabaseContext context)
        {
            _context = context;
        }

        public GetByIdProductQueryResponse GetByIdProduct(GetByIdProductQueryRequest request)
        {
            var data = _context.Products.FirstOrDefault(x => x.Id.Equals(request.Id));
            return new GetByIdProductQueryResponse()
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price,
                Quantity = data.Quantity,
                CreateTime = data.CreateTime
            };
        }

    }
}
