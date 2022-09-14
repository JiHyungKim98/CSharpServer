using ServerTest1.Model;
using ServerTest1.Model.HttpCommand;

namespace ServerTest1.Service;

public class AccountService:IAccountService
{
    private Dictionary<string,Account> _accountDic { get; set; }
    public AccountService()
    {
        _accountDic = new Dictionary<string,Account>();
    }

    public LoginResponse Login(LoginRequest loginRequest)
    {
        LoginResponse response = new LoginResponse();
        // 로그인 하는데 정보가 없는 경우
        if (!_accountDic.ContainsKey(loginRequest.Id))
        {
            response.Result = "Unknown Account";
        }
        // 로그인 하는데 정보가 있는 경우
        else
        {
            // 비밀번호 확인
            var pass = _accountDic.Where(x=>x.Key==loginRequest.Id).Select(x => x.Value.Password).First();
            
            if (loginRequest.Password.Equals(pass)) // 비밀번호 일치
            {
                response.Result = "Hello "+loginRequest.Id+"!";
            }
            else // 비밀번호 불일치
            {
                response.Result = "Password wrong!";
            }
        }
        return response;
    }

    public AccountCreateResponse Create(AccountCreateRequest accountCreateRequest)
    {
        AccountCreateResponse response=new AccountCreateResponse();

        // 이미 있는 계정인지 확인
        if (_accountDic.ContainsKey(accountCreateRequest.Id))
        {
            // 이미 있는 계정이라고 메세지
            response.Result = "Already exists";
        }
        // 없는 계정이면
        else
        {
            Account account = new Account();
            account.Id = accountCreateRequest.Id;
            account.Password = accountCreateRequest.Password;
            account.CreateAt = DateTime.Now;

            _accountDic.Add(account.Id, account);
            
            response.Result = "ID has been created";
            
        }
        return response;
    }
    
}
