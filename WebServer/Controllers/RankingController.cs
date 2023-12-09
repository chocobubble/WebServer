using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using WebServer.Model;

// ��ŷ ��Ʈ�ѷ��� �����
// ��ŷ�� �����ϴ� ���
// ��ü ��ŷ�� �ҷ����� ��� (1~100�����)
// ���� ��ŷ�� �ҷ����� ��� (1~100�����)

namespace WebServer.Controllers
{ 
    [ApiController]
    [Route("[controller]/[action]")]
    public class RankingController : ControllerBase
    {

        private readonly ILogger<RankingController> _logger;

        public RankingController(ILogger<RankingController> logger)
        {
            _logger = logger;
        }

        

        [HttpGet]
        public string GetMyRank()
        {
            return AccountController.accountManagerInstance.GetLoginUserRank();
        }

        [HttpGet]
        public string PrintMyInfo()
        {
            return AccountController.accountManagerInstance.PrintLoginUserInfo();
        }

        [HttpGet]
        public string PrintAllScorer()
        {
            return AccountController.accountManagerInstance.PrintAllScorer();
        }
    }
}

