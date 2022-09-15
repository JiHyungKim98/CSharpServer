using ServerTest1.Model.HttpCommand;

namespace ServerTest1.Service;

public interface IRankingService
{
    public Dictionary<string, UserInfo> AllUserInfo();
    public List<string> GetRankings(string Id);
    public bool AddRanking(string Id, int score);
}
