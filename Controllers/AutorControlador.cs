using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tienda.Microservicios.Autor.Api.Aplicacion;
using Tienda.Microservicios.Autor.Api.Aplication; // Asegúrate que los espacios de nombres sean correctos

namespace Tienda.Microservicios.Autor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorControlador : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorControlador(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetAutores()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutorLibro(string id)
        {
            return await _mediator.Send(new ConsultarFiltro.AutorUnico { AutorGuid = id });
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<AutorDto>> GetAutorPorNombre(string nombre)
        {
            return await _mediator.Send(new ConsultaNombre.AutorUnico { Nombre = nombre });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CrearAutor([FromBody] Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }
    }
}