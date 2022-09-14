using ServerTest1.Model.HttpCommand;

namespace ServerTest1.Service;

public interface IRankingService
{
    public List<string> GetRankings(UserInfo info);
    public bool AddRanking(string Id, int score);
}
