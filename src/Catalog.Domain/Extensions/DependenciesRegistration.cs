using System.Reflection;
using AutoMapper;
using Catalog.Domain.Mappers;
using Catalog.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

namespace Catalog.Domain.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services
                .AddSingleton<IArtistMapper, ArtistMapper>()
                .AddSingleton<IGenreMapper, GenreMapper>()
                .AddSingleton<IItemMapper, ItemMapper>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IItemService, ItemService>();
            return services;
        }

        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder
                .AddFluentValidation(configuratiom =>
                    configuratiom.RegisterValidatorsFromAssembly
                        (Assembly.GetExecutingAssembly()));
            return builder;
        }
    }
}