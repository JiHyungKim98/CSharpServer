using ServerTest1.Model;
using ServerTest1.Model.HttpCommand;

namespace ServerTest1.Service;

public class RankingService:IRankingService
{
    private Dictionary<string,UserInfo> _rankingDic { get; set; }
    public RankingService()
    {
        _rankingDic = new Dictionary<string,UserInfo>();
    }
    public Dictionary<string, UserInfo> AllUserInfo()
    {
        return _rankingDic;
    }
    public List<string> GetRankings(string Id)
    {
        List<string> userRankings = new List<string>();
        // 랭킹 정보가 없는경우
        if (!_rankingDic.ContainsKey(Id))
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Id = Id;
            userInfo.Score = 0;
            userInfo.Ranking = 0;

            _rankingDic.Add(Id, userInfo);
        }

        userRankings.Add(_rankingDic[Id].Id);
        userRankings.Add(_rankingDic[Id].Score.ToString());
        userRankings.Add(_rankingDic[Id].Ranking.ToString());

        return userRankings;

        throw new NotImplementedException();
    }

    public bool AddRanking(string Id,int score)
    {
        // 랭킹 최초 생성 시
        if (!_rankingDic.ContainsKey(Id))
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Id = Id;
            userInfo.Score = score;
            userInfo.Ranking = 0;

            _rankingDic.Add(Id, userInfo);
        }
        else
        {
            int tmpScore = _rankingDic.Where(x => _rankingDic.ContainsKey(Id)).Select(x => x.Value.Score).First();
            // 기록 갱신인 경우
            if (score > tmpScore)
                _rankingDic[Id].Score = score;
            return true;
        }

        throw new NotImplementedException();
    }
}
