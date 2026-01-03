using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccountOperations = Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http;

[ApiController]
[Route("/api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("create-account")]
    public ActionResult<AccountDto> CreateAccount([FromBody] CreateAccountRequest httpRequest)
    {
        var request = new AccountOperations.CreateAccount.Request(
            httpRequest.Balance,
            httpRequest.PinCode,
            httpRequest.SessionKey);

        AccountOperations.CreateAccount.Response response = _accountService.CreateAccount(request);

        return response switch
        {
            AccountOperations.CreateAccount.Response.Success success => Ok(success.Account),
            AccountOperations.CreateAccount.Response.InvalidSessionKey => Unauthorized(),
            AccountOperations.CreateAccount.Response.OperationIsNotAllowed => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("check-balance")]
    public ActionResult<AccountDto> CheckBalance([FromBody] CheckBalanceRequest httpRequest)
    {
        var request = new AccountOperations.CheckBalance.Request(httpRequest.SessionKey);

        AccountOperations.CheckBalance.Response response = _accountService.CheckBalance(request);

        return response switch
        {
            AccountOperations.CheckBalance.Response.Success success => Ok(success.Balance),
            AccountOperations.CheckBalance.Response.InvalidSessionKey => Unauthorized(),
            AccountOperations.CheckBalance.Response.OperationIsNotAllowed => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("replenish-money")]
    public ActionResult ReplenishMoney([FromBody] ReplenishMoneyRequest httpRequest)
    {
        var request = new AccountOperations.ReplenishMoney.Request(
            httpRequest.Amount,
            httpRequest.SessionKey);

        AccountOperations.ReplenishMoney.Response response = _accountService.ReplenishMoney(request);

        return response switch
        {
            AccountOperations.ReplenishMoney.Response.Success success => Ok(),
            AccountOperations.ReplenishMoney.Response.InvalidSessionKey => Unauthorized(),
            AccountOperations.ReplenishMoney.Response.OperationIsNotAllowed => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw-money")]
    public ActionResult WithdrawMoney([FromBody] WithdrawMoneyRequest httpRequest)
    {
        var request = new AccountOperations.WithdrawMoney.Request(
            httpRequest.Amount,
            httpRequest.SessionKey);

        AccountOperations.WithdrawMoney.Response response = _accountService.WithdrawMoney(request);

        return response switch
        {
            AccountOperations.WithdrawMoney.Response.Success success => Ok(),
            AccountOperations.WithdrawMoney.Response.InvalidSessionKey => Unauthorized(),
            AccountOperations.WithdrawMoney.Response.OperationIsNotAllowed => Unauthorized(),
            AccountOperations.WithdrawMoney.Response.NotEnoughMoney => BadRequest(),
            _ => throw new UnreachableException(),
        };
    }
}
