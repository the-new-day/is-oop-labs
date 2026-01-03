using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();

        return collection;
    }

    public static IServiceCollection AddSessionService(
        this IServiceCollection collection,
        IConfiguration configuration)
    {
        var systemPassword = configuration["Admin:SystemPassword"]
            ?? throw new InvalidOperationException("Admin:SystemPassword is not configured");

        collection.AddScoped<ISessionService>(sp =>
        {
            var context = sp.GetRequiredService<IPersistenceContext>();
            return new SessionService(context, systemPassword);
        });

        return collection;
    }
}
