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
    public List<string> GetRankings(UserInfo info)
    {
        // 요청한 유저의 계정이 있는지 확인
        
        // 계정이 있다면?
        //_rankingService.GetRankings();
        // 응답으로 랭킹 리스트 전달

        return null;
    }

    [HttpPost("AddRanking")]
    public bool AddRanking(string Id,int score)
    {
        // 요청한 유저의 계정이 있는지 확인
        //_rankingService.AddRanking(Id, score);
        // 계정이 있다면?
        // 보내준 점수를 등록
        return false;
    }
}
