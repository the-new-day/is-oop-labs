using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Operations = Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.AccountOperations.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("/api/account-operations")]
public sealed class AccountOperationController : ControllerBase
{
    private readonly IAccountOperationService _operationService;

    public AccountOperationController(IAccountOperationService operationService)
    {
        _operationService = operationService;
    }

    [HttpPost("check-history")]
    public ActionResult<OperationHistoryDto> CheckOperationHistory([FromBody] CheckOperationHistoryRequest httpRequest)
    {
        var request = new Operations.CheckOperationHistory.Request(httpRequest.SessionKey);

        Operations.CheckOperationHistory.Response response = _operationService.CheckHistory(request);

        return response switch
        {
            Operations.CheckOperationHistory.Response.Success success => Ok(success.OperationHistory),
            Operations.CheckOperationHistory.Response.InvalidSessionKey => Unauthorized(),
            Operations.CheckOperationHistory.Response.OperationIsNotAllowed => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}
