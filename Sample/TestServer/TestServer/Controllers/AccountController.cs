using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestServer.Model;

namespace TestServer.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AccountController : ControllerBase
{
    private static Dictionary<string, string> _accountInfo = new Dictionary<string, string>();
    
    
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public string Login(LoginParam param)
    {
        if (!_accountInfo.TryGetValue(param.Id, out string password))
        {
            return "없는 아이디 입니다.";
        }

        if (password != param.Password)
        {
            return "비밀번호가 틀립니다.";
        }
        
        return "로그인 되었습니다.";
    }
    
    [HttpPost]
    public string Create(CreateAccountParam param)
    {
        if (_accountInfo.TryGetValue(param.Id, out _))
        {
            return "이미 존재하는 Id 입니다.";
        }

        _accountInfo.Add(param.Id, param.Password);
        return "계정이 생성되었습니다.";
    }
    
    [HttpPost]
    public string Test()
    {
        return $"{Thread.CurrentThread.ManagedThreadId}";
    }
}

// 랭킹 컨트롤러를 만들고
// 랭킹을 저장하는 기능
// 전체 랭킹을 불러오는 기능 (1~100등까지)
// 나의 랭킹을 불러오는 기능 (1~100등까지)