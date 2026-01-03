using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

internal sealed class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;

    private readonly string _systemPassword;

    public SessionService(IPersistenceContext context, string systemPassword)
    {
        _context = context;
        _systemPassword = systemPassword;
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        if (request.SystemPassword != _systemPassword)
            return new CreateAdminSession.Response.WrongSystemPassword();

        Session session = new Session(new AdminSession());
        _context.Sessions.Add(session);

        return new CreateAdminSession.Response.Success(session.MapToDto());
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        var accountId = new AccountId(request.AccountId);

        Account? account = _context.Accounts
            .Query(new AccountQuery.Builder().WithId(accountId).Build())
            .SingleOrDefault();

        if (account is null)
            return new CreateUserSession.Response.AccountNotFound();

        PinCode pinCode = new PinCode(request.PinCode);

        if (account.PinCode.Verify(pinCode) is false)
            return new CreateUserSession.Response.WrongPinCode();

        Session session = new Session(new UserSession());
        _context.Sessions.Add(session);
        _context.SessionAccounts.Add(session.Key, accountId);

        return new CreateUserSession.Response.Success(session.MapToDto());
    }
}
