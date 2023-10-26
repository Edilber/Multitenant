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
    public class GetProductosQuery : IRequest<List<Producto>>
    {

    }

    public class GetProductosHandler : IRequestHandler<GetProductosQuery, List<Producto>>
    {
        private readonly IProductoQueryRepository _productoRepository;
        public GetProductosHandler(IProductoQueryRepository productoRepositorys)
        {
            _productoRepository = productoRepositorys;
        }
        public async Task<List<Producto>> Handle(GetProductosQuery request, CancellationToken cancellationToken)
        {
            return (List<Producto>)await _productoRepository.GetAllAsync();
        }
    }
}
