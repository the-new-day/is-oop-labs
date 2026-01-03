using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public sealed class SessionService : ISessionService
{
    private readonly IPersistanceContext _context;

    public SessionService(IPersistanceContext context)
    {
        _context = context;
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        // TODO: config file
        if (request.SystemPassword != "admin")
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
