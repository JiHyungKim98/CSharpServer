using ServerTest1.Model;
using ServerTest1.Model.HttpCommand;

namespace ServerTest1.Service;

public class RankingService:IRankingService
{
    private AccountService _accountService;
    private Dictionary<string,UserInfo> _rankingDic { get; set; }
    public RankingService()
    {
        _accountService = new AccountService();
        _rankingDic = new Dictionary<string,UserInfo>();
    }

    public List<string> GetRankings(UserInfo info)
    {
        List<string> a = new List<string>();
        a.Add("1");
        a.Add("2");
        
        return a;
        throw new NotImplementedException();
    }
    public bool AddRanking(string Id,int score)
    {
        // 랭킹 정보가 없는경우
        if (!_rankingDic.ContainsKey(Id))
        {
            UserInfo user = new UserInfo();
            user.Id = Id;
            user.Ranking = 0;
            user.Score = 0;

            _rankingDic.Add(Id, user);
        }
           

        // 랭킹 정보가 있는 경우
        else
        {
            int tmpScore= _rankingDic.Where(x => _rankingDic.ContainsKey(Id)).Select(x => x.Value.Score).First();
            // 기록 갱신인 경우
            if (score > tmpScore)
                _rankingDic[Id].Score = score;
        }
        throw new NotImplementedException();
    }
}
