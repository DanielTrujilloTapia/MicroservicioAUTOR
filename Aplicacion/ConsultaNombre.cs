using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tienda.Microservicios.Autor.Api.Modelo;
using Tienda.Microservicios.Autor.Api.Persistencia;

namespace Tienda.Microservicios.Autor.Api.Aplicacion
{
    public class ConsultaNombre
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public string Nombre { get; set; }
        }
        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            private readonly ContextoAutor _context;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _context.AutorLibros
                    .Where(p => p.Nombre == request.Nombre).FirstOrDefaultAsync();
                if (autor == null)
                {
                    throw new Exception("No se encontro El autor");
                }

                var autorDto = _mapper.Map<AutorLibro, AutorDto>(autor);
                return autorDto;
            }

        }
    }
}