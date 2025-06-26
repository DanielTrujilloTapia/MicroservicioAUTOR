using Microsoft.EntityFrameworkCore;
using Tienda.Microservicios.Autor.Api.Persistencia;
using MediatR;
using FluentValidation.AspNetCore;
using Tienda.Microservicios.Autor.Api.Aplicacion;
using Tienda.Microservicios.Autor.Api.Aplication;



namespace Tienda.Microservicios.Autor.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddcustomServices(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddControllers()
                .AddFluentValidation(cfg =>
                cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

            services.AddDbContext<ContextoAutor>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
            services.AddAutoMapper(typeof(Consulta.Manejador));

            return services;
        }
    }
}