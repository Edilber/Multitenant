using Back.Core.Entities;
using Back.Core.Repositories.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Queries.Productos
{
    public class GetProductoByIdQuery : IRequest<Producto>
    {
        public int ProductoId { get; set; }
    }

    public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, Producto>
    {

        private readonly IProductoQueryRepository _productRepository;
        public GetProductoByIdHandler(IProductoQueryRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Producto> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            return (Producto) await _productRepository.GetProductoById(request.ProductoId);
        }
    }
}
