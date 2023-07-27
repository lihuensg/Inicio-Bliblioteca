using System;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Aplication.DAL.EntityFramework;
using Aplication.DAL;
using Aplication;
using Aplication.Servicios.LibrosRemotos;
using Aplication.Servicios.LibrosRemotos.OpenLibrary;
using Aplication.Servicios.Seguridad;
using Aplication.Servicios.Tiempo;

public static partial class InyeccionDeDependencias
{
    public static IServiceCollection AgregarAplicacion(this IServiceCollection servicios)
    {
        servicios.AddTransient<IHashingManager, HashingManager>();

        servicios.AddScoped<Fachada>();

        // HttpClient
        servicios.AddHttpClient("OpenLibrary", client =>
        {
            client.BaseAddress = new Uri("https://openlibrary.org/");
        });

        return servicios;
    }

    public static IServiceCollection AgregarLibrosRemotos(this IServiceCollection servicios)
    {
        servicios.AddTransient<IServiciosEdicion, ServiceEdicionesOpenLibrary>();
        return servicios;
    }

    public static IServiceCollection AgregarPersistencia(this IServiceCollection servicios)
    {
        // DbContext
        servicios.AddScoped<BibliotecaDbContext>();
        // UnitOfWork
        servicios.AddScoped<IUnitOfWork, UnitOfWork>();
        servicios.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
        // Repositorios
        servicios.AddScoped<IRepositorioEjemplares, RepositorioEjemplares>();
        servicios.AddScoped<IRepositorioPrestamos, RepositorioPrestamos>();
        servicios.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
        servicios.AddScoped<IRepositorioEdiciones, RepositorioEdiciones>();
        servicios.AddScoped<IRepositorioNotificacionVencimientoPrestamo, RepositorioNotificacionVencimientoPrestamo>();

        return servicios;
    }

    public static IServiceCollection AgregarTiempo(this IServiceCollection servicios)
    {
        servicios.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return servicios;
    }
}