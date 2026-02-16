using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection collection,
        IConfiguration configuration)
    {
        string systemPassword = configuration["Admin:SystemPassword"]
            ?? throw new InvalidOperationException("Admin:SystemPassword is not configured");

        collection.AddScoped<ISessionService>(sp =>
        {
            IPersistenceContext context = sp.GetRequiredService<IPersistenceContext>();
            return new SessionService(context, systemPassword);
        });

        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAccountOperationService, AccountOperationService>();

        return collection;
    }
}
