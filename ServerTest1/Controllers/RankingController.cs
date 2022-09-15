using Microsoft.AspNetCore.Mvc;
using ServerTest1.Model.HttpCommand;
using ServerTest1.Service;

namespace ServerTest1.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class RankingController:ControllerBase
{
    private readonly ILogger<RankingController> _logger;
    private IAccountService _accountService;
    private IRankingService _rankingService;

    
    public RankingController(ILogger<RankingController> logger, IAccountService accountService, IRankingService rankingService)
    {
        _logger = logger;
        _accountService = accountService;
        _rankingService = rankingService;
    }

    [HttpPost("GetRanking")]
    public string GetRankings(string Id)
    {
        // 요청한 유저의 계정이 있는지 확인
        // 계정이 없으면
        if (!_accountService.isExist(Id))
            return "Unknown Account!";

        // 계정이 있으면 랭킹 리스트 전달
        var tmp=_rankingService.GetRankings(Id);
        if (tmp.Count == 0)
        {
            return "Please Add Ranking";
        }
        else
        {
            string result = "Id : "+tmp[0]+"\n"
                        +"Score : "+tmp[1]+"\n"
                        + "Ranking : " + tmp[2];
            return result;
        }
    }

    [HttpPost("AddRanking")]
    public string AddRanking(string Id,int score)
    {
        // 요청한 유저의 계정이 없는 경우
        if (!_accountService.isExist(Id))
            return "Unknown Account";

        // 요청한 유저의 계정이 있는 경우 등록 및 업데이트
        _rankingService.AddRanking(Id, score);
        return "Ranking Update Success!";
    }
}
