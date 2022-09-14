using Microsoft.AspNetCore.Mvc;
using ServerTest1.Model.HttpCommand;
using ServerTest1.Service;

namespace ServerTest1.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class AccountController:ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private IAccountService _accountService;


    public AccountController(ILogger<AccountController> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }
    [HttpPost("Login")]
    public LoginResponse Login(LoginRequest loginRequest)
    {
        return _accountService.Login(loginRequest);
    }
    [HttpPost("Create")]
    public AccountCreateResponse Create(AccountCreateRequest accountCreateRequest)
    {
        return _accountService.Create(accountCreateRequest);
    }
}
