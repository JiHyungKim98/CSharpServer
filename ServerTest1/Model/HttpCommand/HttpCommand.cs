namespace ServerTest1.Model.HttpCommand;

public class LoginRequest
{
    public string Id { get; set; }
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Result { get; set; }
}

public class AccountCreateRequest
{
    public string Id { get; set; }
    public string Password { get; set; }
}

public class AccountCreateResponse
{
    public string Result { get; set; }
}

public class UserInfo
{
    public string Id { get; set; }
    public int Score { get; set; }
    public int Ranking { get; set; }
}