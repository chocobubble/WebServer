
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Model
{
    [Table("account")]
    public class AccountData
    {
        public AccountData(int id, string userId, string userPassword )
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
    public class Character
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
        [Column("weapon_type")]
        public int WeaponType { get; set; }
        [Column("weapon_level")]
        public int WeaponLevel { get; set; }
        [Column("weapon_enhancement_level")]
        public int WeaponEnhancementLevel { get; set; }
        [Column("rifle_ammo")]
        public int RifleAmmo { get; set; }


        public Character() { }

        public Character(int id, int accountId, CharacterData data)
        {
            Id = id;
            AccountId = accountId;
            Level = data.level;
            Exp = data.exp;
            Name = data.playerName;
            Gold = data.gold;
            this.WeaponType = (int)data.weaponData.weaponType;
            this.WeaponLevel = data.weaponData.weaponLevel;
            this.WeaponEnhancementLevel = data.weaponData.weaponEnhancementLevel;
            RifleAmmo = data.rifleAmmo;
        }

        public void SaveCharactereData(CharacterData data)
        {
            Level = data.level;
            Exp = data.exp;
            Name = data.playerName;
            Gold = data.gold;
            this.WeaponType = (int)data.weaponData.weaponType;
            this.WeaponLevel = data.weaponData.weaponLevel;
            this.WeaponEnhancementLevel = data.weaponData.weaponEnhancementLevel;
            RifleAmmo = data.rifleAmmo;
        }
    }
}