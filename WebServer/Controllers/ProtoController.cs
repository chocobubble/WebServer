using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
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
        /*
        [HttpGet]
        public string Hello()
        {
            return _protoTestService.Hello();
        }

        [HttpGet]
        public string NewHello()
        {
            return _protoTestService.SerializeHello();
        }
        */
        [HttpGet]
        public string LoadCharacterData()
        {
            return _loadService.ProtoTest();
        }

        [HttpGet]
        public byte[] ProtoTest1()
        {
            //CharacterData characterData = new CharacterData();
            //WeaponSaveData weaponSaveData = new WeaponSaveData();
            //weaponSaveData.WeaponType = WeaponSaveData.Types.WeaponType.EwtRifle;
            //weaponSaveData.WeaponLevel = 2;
            //weaponSaveData.WeaponEnhancementLevel = 3;
            //characterData.Level = 3;
            //characterData.Exp = 5;
            //characterData.PlayerName = "palyer";
            //characterData.Gold = 100;
            ////characterData.WeaponSaveData = weaponSaveData;
            //characterData.WeaponSaveData = new WeaponSaveData();
            //characterData.WeaponSaveData.WeaponLevel = 2;
            //characterData.WeaponSaveData.WeaponEnhancementLevel = 3;
            //characterData.WeaponSaveData.WeaponType = WeaponSaveData.Types.WeaponType.EwtRifle;
            //characterData.RifleAmmo = 1000;
            //byte[] bytes = Encoding.UTF8.GetBytes("prototo");

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
            //CharacterData characterData = new CharacterData();
            //WeaponSaveData weaponSaveData = new WeaponSaveData();
            //weaponSaveData.WeaponType = WeaponSaveData.Types.WeaponType.EwtRifle;
            //weaponSaveData.WeaponLevel = 2;
            //weaponSaveData.WeaponEnhancementLevel = 3;
            //characterData.Level = 3;
            //characterData.Exp = 5;
            //characterData.PlayerName = "palyer";
            //characterData.Gold = 100;
            ////characterData.WeaponSaveData = weaponSaveData;
            //characterData.WeaponSaveData = new WeaponSaveData();
            //characterData.WeaponSaveData.WeaponLevel = 2;
            //characterData.WeaponSaveData.WeaponEnhancementLevel = 3;
            //characterData.WeaponSaveData.WeaponType = WeaponSaveData.Types.WeaponType.EwtRifle;
            //characterData.RifleAmmo = 1000;
            //byte[] bytes = Encoding.UTF8.GetBytes("prototo");

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
    }
}

