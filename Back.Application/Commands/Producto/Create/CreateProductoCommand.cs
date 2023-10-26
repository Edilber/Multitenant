using Back.Application.DTOs;
using Back.Application.Mapper;
using Back.Core.Entities;
using Back.Core.Repositories.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Commands.Producto.Create
{
    public record CreateProductoCommand(ProductoDto producto) : IRequest<ProductoResponse>
    {

    }

    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, ProductoResponse>
    {
        private readonly IProductoCommandRepository _productoCommandRepository;

        public CreateProductoCommandHandler(IProductoCommandRepository productoCommandRepository)
        {
            _productoCommandRepository = productoCommandRepository;
        }

        public async Task<ProductoResponse> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var productoEntity = CustomerMapper.Mapper.Map<Core.Entities.Producto>(request.producto);

            if (productoEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newProduct = await _productoCommandRepository.AddAsync(productoEntity);
            var productoResponse = CustomerMapper.Mapper.Map<ProductoResponse>(newProduct);

            return productoResponse;
        }
    }
}
