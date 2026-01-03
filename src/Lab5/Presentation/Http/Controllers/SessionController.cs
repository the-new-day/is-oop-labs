using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SessionOperations = Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http;

[ApiController]
[Route("/api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("create-admin-session")]
    public ActionResult<SessionDto> CreateAdminSession([FromBody] CreateAdminSessionRequest httpRequest)
    {
        var request = new SessionOperations.CreateAdminSession.Request(httpRequest.SystemPassword);
        SessionOperations.CreateAdminSession.Response response = _sessionService.CreateAdminSession(request);

        return response switch
        {
            SessionOperations.CreateAdminSession.Response.Success success => Ok(success.Session),
            SessionOperations.CreateAdminSession.Response.WrongSystemPassword => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("create-user-session")]
    public ActionResult<SessionDto> CreateUserSession([FromBody] CreateUserSessionRequest httpRequest)
    {
        var request = new SessionOperations.CreateUserSession.Request(httpRequest.AccountId, httpRequest.PinCode);
        SessionOperations.CreateUserSession.Response response = _sessionService.CreateUserSession(request);

        return response switch
        {
            SessionOperations.CreateUserSession.Response.Success success => Ok(success.Session),
            SessionOperations.CreateUserSession.Response.AccountNotFound => NotFound(),
            SessionOperations.CreateUserSession.Response.WrongPinCode => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}
