using Microsoft.AspNetCore.Mvc;
using ServerTest1.Model.HttpCommand;
using ServerTest1.Service;

namespace ServerTest1.Controllers;


[ApiController]
[Route("api/[Controller]")]
public class AdminController:ControllerBase
{
    private readonly ILogger<AdminController> _logger;
    private IRankingService _rankingService;
    private IAccountService _accountService;

    public AdminController(ILogger<AdminController> logger, IRankingService rankingService,IAccountService accountService)
    {
        _logger = logger;
        _rankingService = rankingService;
        _accountService = accountService;
    }

    [HttpPost("GetRanking")]
    public Dictionary<string, UserInfo> AllUserList()
    {
        var userInfo = _rankingService.AllUserInfo();
        var userAccount=_accountService.AllUserAccount();

        Dictionary<string, string> resultDic=new Dictionary<string, string>();



        return userInfo;
    }
}
