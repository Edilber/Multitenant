using Back.Application.Commands.Producto.Create;
using Back.Application.Commands.Producto.Update;
using Back.Application.DTOs;
using Back.Application.Queries.Productos;
using Back.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IMediator _mediator;
        
        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("productos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Producto>> GetAllProductos()
        {
            return await _mediator.Send(new GetProductosQuery());
        }

        [HttpGet("productos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            return await _mediator.Send(new GetProductoByIdQuery() { ProductoId = id });
        }

        [HttpPost("productos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductoResponse>> CreateProducto([FromBody] ProductoDto producto)
        {
            var result = await _mediator.Send(new CreateProductoCommand(producto));
            return Ok(result);
        }

        [HttpPut("productos/{id}")]
        public async Task<ActionResult<Producto>> PutProducto(int id, EditProductoDto producto)
        {
            if (id != producto.ProductoId)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateProductoCommand(producto));
            return Ok(result);
        }
    }
}
