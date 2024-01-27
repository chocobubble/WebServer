
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Model
{
    [Table("account")]
    public class AccountDataEntity
    {
        public AccountDataEntity(int id, string userId, string userPassword )
        {
            Id = id;
            UserId = userId;
            UserPassword = userPassword;
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("user_password")]
        public string UserPassword { get; set; }
    }

    [Table("character_data")]
    public class CharacterDataEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        [Column("level")]
        public int Level { get; set; }
        [Column("exp")]
        public int Exp { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("gold")]
        public int Gold { get; set; }


        public CharacterDataEntity() { }

        public CharacterDataEntity(int id, int accountId)
        {
            Id = id;
            AccountId = accountId;
            Level = 1;
            Exp = 0;
            Name = "default";
            Gold = 1000;
        }

        public void SaveCharactereData(CharacterData data)
        {
            Level = data.level;
            Exp = data.exp;
            Name = data.player_name;
            Gold = data.gold;
            //this.WeaponType = (int)data.weaponData.weaponType;
            //this.WeaponLevel = data.weaponData.weaponLevel;
            //this.WeaponEnhancementLevel = data.weaponData.weaponEnhancementLevel;
        }
    }

    [Table("weapon_data")]
    public class WeaponDataEntity
    {
        public WeaponDataEntity()
        {
        }

        public WeaponDataEntity(string uid, int accountId)
        {
            Uid = uid;
            AccountId = accountId;
            WeaponId = 1;
            Level = 1;
            Enhancement = 0;
        }

        public WeaponDataEntity(string uid, int accountId, WeaponData weaponData)
        {
            Uid = uid;
            AccountId = accountId;
            WeaponId = weaponData.weapon_id;
            Level = weaponData.level;
            Enhancement = weaponData.enhancement;
        }

        [Column("uid")]
        public string Uid { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        [Column("weapon_id")]
        public int WeaponId { get; set; }
        [Column("level")]
        public int Level { get; set; }
        [Column("enhancement")]
        public int Enhancement { get; set; }
    }
}