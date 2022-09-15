using ServerTest1.Model;
using ServerTest1.Model.HttpCommand;
namespace ServerTest1.Service;


public interface IAccountService
{
    public Dictionary<string, Account> AllUserAccount();
    bool isExist(string Id);
    LoginResponse Login(LoginRequest loginRequest);
    AccountCreateResponse Create(AccountCreateRequest createRequest);
}
