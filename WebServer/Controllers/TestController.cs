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
            data.playerName = "player";
            data.level = 2;
            data.exp = 5;
            data.rifleAmmo = 11;
            WeaponData weaponData2 = new WeaponData();
            weaponData2.weaponEnhancementLevel = 5;
            weaponData2.weaponLevel = 2;
            weaponData2.weaponType = Model.WeaponType.EWT_RIFLE;
            data.weaponData = weaponData2;

            response2.apiReturnCode = ApiReturnCode.Success;
            //response2.test = 7;

            response2.characterData = data;


            //_logger.Log(LogLevel.Warning, $"api return code : {response2.apiReturnCode}");
            return response2;
        }

        [HttpGet]
        public CharacterDataLoadResponse test2()
        {
            CharacterDataLoadResponse response = new CharacterDataLoadResponse();
            CharacterData data = new CharacterData();
            data.gold = 1;
            data.playerName = "player";
            data.level = 2;
            data.exp = 5;
            data.rifleAmmo = 11;
            WeaponData weaponData2 = new WeaponData();
            weaponData2.weaponEnhancementLevel = 5;
            weaponData2.weaponLevel = 2;
            weaponData2.weaponType = Model.WeaponType.EWT_RIFLE;
            data.weaponData = weaponData2;


            response.apiReturnCode = ApiReturnCode.Success;
            response.characterData = data;
            return response;
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
        public String test5(CharacterDataLoadResponse2 response2)
        {
            
            ApiReturnCode code = response2.apiReturnCode;
            CharacterData data = response2.characterData;
            String str = $"api retrun code : {response2.apiReturnCode}\n";
            //String str = $"api retrun code : {response2.test}\n";
            str += $"weapon type : {data.weaponData.weaponType}\n";
            str += $"player name : {data.playerName}\n";
            //str += $"another api return code : {code}\n";
            //Console.WriteLine(RuntimeTypeModel.Default.GetSchema(typeof(CharacterDataLoadResponse2)));
            return str;
        }

        [HttpPost]
        public CharacterDataLoadResponse2 test6()
        {
            return test1();
        }

        [HttpPost]
        public String test7()
        {
            CharacterDataLoadResponse2 response2 = test1();
            ApiReturnCode code = response2.apiReturnCode;
            CharacterData data = response2.characterData;
            String str = $"api retrun code : {response2.apiReturnCode}\n";
            //String str = $"api retrun code : {response2.test}\n";
            str += $"weapon type : {data.weaponData.weaponType}\n";
            str += $"player name : {data.playerName}\n";
            //str += $"another api return code : {code}\n";
            //Console.WriteLine(RuntimeTypeModel.Default.GetSchema(typeof(CharacterDataLoadResponse2)));
            return str;
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
            //string proto = Serializer.GetProto<CharacterDataLoadResponse2>();
            string proto = Serializer.GetProto<WeaponType>();
            return proto;
        }

        [HttpPost]
        public string test10()
        {
            //string proto = Serializer.GetProto<CharacterDataLoadResponse2>();
            string proto = Serializer.GetProto<ApiReturnCode>();
            return proto;
        }

    }
}