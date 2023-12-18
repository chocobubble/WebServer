using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using WebServer.HttpCommand;
using WebServer.Model;
using WebServer.Protos;
using WebServer.Repository.Interface;
using WebServer.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProtoController : ControllerBase
    {
        private readonly ILogger<ProtoController> _logger;

        private ProtoTestService _protoTestService;

        private LoadService _loadService;

        public ProtoController(ILogger<ProtoController> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _protoTestService = new ProtoTestService();
            _loadService = new LoadService(accountRepository);
        }

        [HttpGet]
        public string LoadCharacterData()
        {
            return _loadService.ProtoTest();
        }

        [HttpGet]
        public byte[] ProtoTest1()
        {
            CharacterData characterData = new CharacterData
            {
                Level = 3,
                Exp = 5,
                PlayerName = "player",
                Gold = 100,
                WeaponSaveData = new WeaponSaveData { WeaponLevel = 2, WeaponEnhancementLevel = 3, WeaponType = WeaponSaveData.Types.WeaponType.EwtRifle },
                RifleAmmo = 1000
            };
            byte[] bytes = characterData.ToByteArray();
            return bytes;
        }

        [HttpGet]
        public ByteString ProtoTest2()
        {
            CharacterData characterData = new CharacterData
            {
                Level = 3,
                Exp = 5,
                PlayerName = "player",
                Gold = 100,
                WeaponSaveData = new WeaponSaveData { WeaponLevel = 2, WeaponEnhancementLevel = 3, WeaponType = WeaponSaveData.Types.WeaponType.EwtRifle },
                RifleAmmo = 1000
            };
            ByteString byteString =  characterData.ToByteString();
            return byteString;
        }

        [HttpGet]
        public String ProtoTest3()
        {

            CharacterData characterData = new CharacterData
            {
                Level = 3,
                Exp = 5,
                PlayerName = "player",
                Gold = 100,
                WeaponSaveData = new WeaponSaveData { WeaponLevel = 2, WeaponEnhancementLevel = 3, WeaponType = WeaponSaveData.Types.WeaponType.EwtRifle },
                RifleAmmo = 1000
            };
            return characterData.ToString();
        }

        [HttpGet]
        public byte[] ProtoTest4()
        {
            ProtoTest protoTest = new ProtoTest
            {
                Num = 1
            };
            byte[] bytes = protoTest.ToByteArray();
            return bytes;
        }

        [HttpGet]
        public ByteString ProtoTest5()
        {
            CharacterData characterData = new CharacterData
            {
                Level = 3,
                Exp = 5,
                PlayerName = "player",
                Gold = 100,
                WeaponSaveData = new WeaponSaveData { WeaponLevel = 2, WeaponEnhancementLevel = 3, WeaponType = WeaponSaveData.Types.WeaponType.EwtRifle },
                RifleAmmo = 1000
            };
            ByteString byteString = characterData.ToByteString();
            return byteString;
        }

        
        [HttpGet]
        public IActionResult ProtoTest6()
        {
            UserSession userSession =  new UserSession() { SessionId = Guid.NewGuid().ToString(), UserId = "Moon", ExpireTime = DateTime.Now, State = "state"};
            return Ok(userSession);
        }

        [HttpGet]
        public ProtoTest ProtoTest7()
        {
            ProtoTest protoTest = new ProtoTest
            {
                Num = 1
            };
            byte[] bytes = protoTest.ToByteArray();
            return protoTest;
        }

        [HttpGet]
        public IActionResult ProtoTest8()
        {
            ProtobufModelDto protobufModelDto =  new ProtobufModelDto() { Id = 1, Name = "moon", StringValue = "str" };
            return Ok(protobufModelDto);
        }

        [HttpGet]
        public IActionResult ProtoTest9()
        {
            CharacterData2 characterData = new CharacterData2
            {
                Level = 3,
                Exp = 5,
                PlayerName = "player",
                Gold = 100,
                weaponSaveData = new WeaponSaveData2 { WeaponLevel = 2, WeaponEnhancementLevel = 3, weaponType = WeaponType.EWT_RIFLE },
                RifleAmmo = 1000
            };
            return Ok(characterData);
        }

        [HttpPost]
        public String ProtoTest10([FromBody]CharacterData2 characterData)
        {
            var data = characterData;
            return data.PlayerName;
        }

        [HttpPost]
        public String ProtoTest11(byte[] bytes)
        {
            CharacterData data;
            data = CharacterData.Parser.ParseFrom(bytes);
            return data.PlayerName;
        }

        [HttpGet]
        public LoginResponse LoginResponseTest()
        {
            LoginResponse loginResponse = new LoginResponse();
            loginResponse.ApiReturnCode = ApiReturnCode.Success;
            loginResponse.SessionId = "session Id";
            return loginResponse;
        }

    }
}

