using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tienda.Microservicios.Autor.Api.Aplicacion;
using Tienda.Microservicios.Autor.Api.Persistencia;

namespace Tienda.Microservicios.Autor.Api.Aplication
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDto>>
        {

        }
        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                this._contexto = contexto;
                this._mapper = mapper;
            }
            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _contexto.AutorLibros.ToListAsync();
                return _mapper.Map<List<AutorDto>>(autores);
            }
        }
    }
}