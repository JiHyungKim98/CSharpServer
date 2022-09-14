using ServerTest1.Model.HttpCommand;
namespace ServerTest1.Service;


public interface IAccountService
{
    LoginResponse Login(LoginRequest loginRequest);
    AccountCreateResponse Create(AccountCreateRequest createRequest);
}
