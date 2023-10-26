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

namespace Back.Application.Commands.Producto.Update
{
    public record UpdateProductoCommand(EditProductoDto producto) : IRequest<ProductoResponse>
    {

    }

    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, ProductoResponse>
    {
        private readonly IProductoCommandRepository _productoCommandRepository;
        public UpdateProductoCommandHandler(IProductoCommandRepository productoCommandRepository)
        {
            _productoCommandRepository = productoCommandRepository;
        }
        public async Task<ProductoResponse> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var productoEntity = CustomerMapper.Mapper.Map<Core.Entities.Producto>(request.producto);

            if (productoEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newProduct = await _productoCommandRepository.UpdateAsync(productoEntity);
            var productResponse = CustomerMapper.Mapper.Map<ProductoResponse>(newProduct);
            return productResponse;
        }
    }
}
