using Microsoft.AspNetCore.Mvc;
using ProtoBuf;
using ProtoBuf.Meta;
using WebServer.HttpCommand;
using WebServer.Model;
using WebServer.Service.Interface;

namespace WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public CharacterDataLoadResponse2 test1()
        {
            CharacterDataLoadResponse2 response2 = new CharacterDataLoadResponse2();
            CharacterData data = new CharacterData();
            data.gold = 1;
            data.player_name = "player";
            data.level = 2;
            data.exp = 5;
            // data.rifleAmmo = 11;
            // WeaponData weaponData2 = new WeaponData();
            // weaponData2.weaponEnhancementLevel = 5;
            // weaponData2.weaponLevel = 2;
            // weaponData2.weaponType = Model.WeaponType.EWT_RIFLE;
            // data.weaponData = weaponData2;

            response2.apiReturnCode = ApiReturnCode.Success;
            //response2.test = 7;

            response2.characterData = data;


            //_logger.Log(LogLevel.Warning, $"api return code : {response2.apiReturnCode}");
            return response2;
        }

        [HttpPost]
        public CharacterDataLoadResponse2 test3(CharacterDataLoadResponse2 response2)
        {
            return response2;
        }

        [HttpPost]
        public CharacterDataLoadResponse test4(CharacterDataLoadResponse response2)
        {
            return response2;
        }


        [HttpPost]
        public CharacterDataLoadResponse2 test6()
        {
            return test1();
        }

        [HttpPost]
        public string test8()
        {
            string proto = Serializer.GetProto<CharacterDataLoadResponse2>();
            //string proto = Serializer.GetProto<WeaponData>();
            return proto;
        }
        [HttpPost]
        public string test9()
        {
            string proto = Serializer.GetProto<CharacterDataLoadResponse>();
            //string proto = Serializer.GetProto<WeaponType>();
            return proto;
        }

        [HttpPost]
        public string test10()
        {
            //string proto = Serializer.GetProto<CharacterDataLoadResponse2>();
            string proto = Serializer.GetProto<ApiReturnCode>();
            return proto;
        }

        [HttpPost]
        public string ErrorTest([FromBody] CreateAccountRequest request)
        {
            return "create aacccount";
        }

        [HttpPost]
        public BaseResponse ErrorTest2(BaseResponse response)
        {
            return response;
        }

        [HttpPost]
        public string FilterTest(CreateAccountRequest request)
        {
            return "Create Account";
        }

        [HttpPost]
        public string FilterTest2([FromBody] CreateAccountRequest request)
        {
            return "Create Account2";
        }

        [HttpPost]
        public BaseResponse FilterTest3([FromBody] BaseResponse response)
        {
            return response;
        }

    }
}