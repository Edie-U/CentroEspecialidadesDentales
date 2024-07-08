using CentroEspecialidadesDentales.Infrastructure.Persistence;
using CentroEspecialidadesDentales.WebUI.Filters;
using CentroEspecialidadesDentales.WebUI.Services;
using CentroEspecialidadesDentales.Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddRazorPages();

        return services;
    }
}
