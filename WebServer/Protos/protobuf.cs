﻿// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: my.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace WebServer.Protos
{

    /// <summary>Holder for reflection information generated from my.proto</summary>
    public static partial class MyReflection
    {

        #region Descriptor
        /// <summary>File descriptor for my.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }
        private static pbr::FileDescriptor descriptor;

        static MyReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                  "CghteS5wcm90byKIAQoMQ2hyYWN0ZXJEYXRhEg0KBWxldmVsGAEgASgFEgsK",
                  "A2V4cBgCIAEoBRISCgpwbGF5ZXJOYW1lGAMgASgJEgwKBGdvbGQYBCABKAUS",
                  "JwoOd2VhcG9uU2F2ZURhdGEYBSABKAsyDy5XZWFwb25TYXZlRGF0YRIRCgly",
                  "aWZsZUFtbW8YBiABKAUigQEKDldlYXBvblNhdmVEYXRhEhIKCndlcG9uTGV2",
                  "ZWwYASABKAUSHQoVd2Vwb25FbmhhbmNlbWVudExldmVsGAIgASgFIjwKCldl",
                  "YXBvblR5cGUSDQoJRVdUX1JJRkxFEAASDgoKRVdUX1BJU1RPTBABEg8KC0VX",
                  "VF9TSE9UR1VOEAJCE6oCEFdlYlNlcnZlci5Qcm90b3NiBnByb3RvMw=="));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { },
                new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::WebServer.Protos.ChracterData), global::WebServer.Protos.ChracterData.Parser, new[]{ "Level", "Exp", "PlayerName", "Gold", "WeaponSaveData", "RifleAmmo" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::WebServer.Protos.WeaponSaveData), global::WebServer.Protos.WeaponSaveData.Parser, new[]{ "WeponLevel", "WeponEnhancementLevel" }, null, new[]{ typeof(global::WebServer.Protos.WeaponSaveData.Types.WeaponType) }, null, null)
                }));
        }
        #endregion

    }
    #region Messages
    public sealed partial class ChracterData : pb::IMessage<ChracterData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        , pb::IBufferMessage
#endif
    {
        private static readonly pb::MessageParser<ChracterData> _parser = new pb::MessageParser<ChracterData>(() => new ChracterData());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public static pb::MessageParser<ChracterData> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::WebServer.Protos.MyReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public ChracterData()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public ChracterData(ChracterData other) : this()
        {
            level_ = other.level_;
            exp_ = other.exp_;
            playerName_ = other.playerName_;
            gold_ = other.gold_;
            weaponSaveData_ = other.weaponSaveData_ != null ? other.weaponSaveData_.Clone() : null;
            rifleAmmo_ = other.rifleAmmo_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public ChracterData Clone()
        {
            return new ChracterData(this);
        }

        /// <summary>Field number for the "level" field.</summary>
        public const int LevelFieldNumber = 1;
        private int level_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int Level
        {
            get { return level_; }
            set
            {
                level_ = value;
            }
        }

        /// <summary>Field number for the "exp" field.</summary>
        public const int ExpFieldNumber = 2;
        private int exp_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int Exp
        {
            get { return exp_; }
            set
            {
                exp_ = value;
            }
        }

        /// <summary>Field number for the "playerName" field.</summary>
        public const int PlayerNameFieldNumber = 3;
        private string playerName_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public string PlayerName
        {
            get { return playerName_; }
            set
            {
                playerName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
            }
        }

        /// <summary>Field number for the "gold" field.</summary>
        public const int GoldFieldNumber = 4;
        private int gold_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int Gold
        {
            get { return gold_; }
            set
            {
                gold_ = value;
            }
        }

        /// <summary>Field number for the "weaponSaveData" field.</summary>
        public const int WeaponSaveDataFieldNumber = 5;
        private global::WebServer.Protos.WeaponSaveData weaponSaveData_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public global::WebServer.Protos.WeaponSaveData WeaponSaveData
        {
            get { return weaponSaveData_; }
            set
            {
                weaponSaveData_ = value;
            }
        }

        /// <summary>Field number for the "rifleAmmo" field.</summary>
        public const int RifleAmmoFieldNumber = 6;
        private int rifleAmmo_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int RifleAmmo
        {
            get { return rifleAmmo_; }
            set
            {
                rifleAmmo_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public override bool Equals(object other)
        {
            return Equals(other as ChracterData);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public bool Equals(ChracterData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Level != other.Level) return false;
            if (Exp != other.Exp) return false;
            if (PlayerName != other.PlayerName) return false;
            if (Gold != other.Gold) return false;
            if (!object.Equals(WeaponSaveData, other.WeaponSaveData)) return false;
            if (RifleAmmo != other.RifleAmmo) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public override int GetHashCode()
        {
            int hash = 1;
            if (Level != 0) hash ^= Level.GetHashCode();
            if (Exp != 0) hash ^= Exp.GetHashCode();
            if (PlayerName.Length != 0) hash ^= PlayerName.GetHashCode();
            if (Gold != 0) hash ^= Gold.GetHashCode();
            if (weaponSaveData_ != null) hash ^= WeaponSaveData.GetHashCode();
            if (RifleAmmo != 0) hash ^= RifleAmmo.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public void WriteTo(pb::CodedOutputStream output)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            output.WriteRawMessage(this);
#else
      if (Level != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Level);
      }
      if (Exp != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Exp);
      }
      if (PlayerName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(PlayerName);
      }
      if (Gold != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Gold);
      }
      if (weaponSaveData_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(WeaponSaveData);
      }
      if (RifleAmmo != 0) {
        output.WriteRawTag(48);
        output.WriteInt32(RifleAmmo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
        {
            if (Level != 0)
            {
                output.WriteRawTag(8);
                output.WriteInt32(Level);
            }
            if (Exp != 0)
            {
                output.WriteRawTag(16);
                output.WriteInt32(Exp);
            }
            if (PlayerName.Length != 0)
            {
                output.WriteRawTag(26);
                output.WriteString(PlayerName);
            }
            if (Gold != 0)
            {
                output.WriteRawTag(32);
                output.WriteInt32(Gold);
            }
            if (weaponSaveData_ != null)
            {
                output.WriteRawTag(42);
                output.WriteMessage(WeaponSaveData);
            }
            if (RifleAmmo != 0)
            {
                output.WriteRawTag(48);
                output.WriteInt32(RifleAmmo);
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(ref output);
            }
        }
#endif

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int CalculateSize()
        {
            int size = 0;
            if (Level != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeInt32Size(Level);
            }
            if (Exp != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeInt32Size(Exp);
            }
            if (PlayerName.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(PlayerName);
            }
            if (Gold != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeInt32Size(Gold);
            }
            if (weaponSaveData_ != null)
            {
                size += 1 + pb::CodedOutputStream.ComputeMessageSize(WeaponSaveData);
            }
            if (RifleAmmo != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeInt32Size(RifleAmmo);
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public void MergeFrom(ChracterData other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Level != 0)
            {
                Level = other.Level;
            }
            if (other.Exp != 0)
            {
                Exp = other.Exp;
            }
            if (other.PlayerName.Length != 0)
            {
                PlayerName = other.PlayerName;
            }
            if (other.Gold != 0)
            {
                Gold = other.Gold;
            }
            if (other.weaponSaveData_ != null)
            {
                if (weaponSaveData_ == null)
                {
                    WeaponSaveData = new global::WebServer.Protos.WeaponSaveData();
                }
                WeaponSaveData.MergeFrom(other.WeaponSaveData);
            }
            if (other.RifleAmmo != 0)
            {
                RifleAmmo = other.RifleAmmo;
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public void MergeFrom(pb::CodedInputStream input)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Level = input.ReadInt32();
            break;
          }
          case 16: {
            Exp = input.ReadInt32();
            break;
          }
          case 26: {
            PlayerName = input.ReadString();
            break;
          }
          case 32: {
            Gold = input.ReadInt32();
            break;
          }
          case 42: {
            if (weaponSaveData_ == null) {
              WeaponSaveData = new global::WebServer.Protos.WeaponSaveData();
            }
            input.ReadMessage(WeaponSaveData);
            break;
          }
          case 48: {
            RifleAmmo = input.ReadInt32();
            break;
          }
        }
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                        break;
                    case 8:
                        {
                            Level = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            Exp = input.ReadInt32();
                            break;
                        }
                    case 26:
                        {
                            PlayerName = input.ReadString();
                            break;
                        }
                    case 32:
                        {
                            Gold = input.ReadInt32();
                            break;
                        }
                    case 42:
                        {
                            if (weaponSaveData_ == null)
                            {
                                WeaponSaveData = new global::WebServer.Protos.WeaponSaveData();
                            }
                            input.ReadMessage(WeaponSaveData);
                            break;
                        }
                    case 48:
                        {
                            RifleAmmo = input.ReadInt32();
                            break;
                        }
                }
            }
        }
#endif

    }

    public sealed partial class WeaponSaveData : pb::IMessage<WeaponSaveData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        , pb::IBufferMessage
#endif
    {
        private static readonly pb::MessageParser<WeaponSaveData> _parser = new pb::MessageParser<WeaponSaveData>(() => new WeaponSaveData());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public static pb::MessageParser<WeaponSaveData> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::WebServer.Protos.MyReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public WeaponSaveData()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public WeaponSaveData(WeaponSaveData other) : this()
        {
            weponLevel_ = other.weponLevel_;
            weponEnhancementLevel_ = other.weponEnhancementLevel_;
            _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public WeaponSaveData Clone()
        {
            return new WeaponSaveData(this);
        }

        /// <summary>Field number for the "weponLevel" field.</summary>
        public const int WeponLevelFieldNumber = 1;
        private int weponLevel_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int WeponLevel
        {
            get { return weponLevel_; }
            set
            {
                weponLevel_ = value;
            }
        }

        /// <summary>Field number for the "weponEnhancementLevel" field.</summary>
        public const int WeponEnhancementLevelFieldNumber = 2;
        private int weponEnhancementLevel_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int WeponEnhancementLevel
        {
            get { return weponEnhancementLevel_; }
            set
            {
                weponEnhancementLevel_ = value;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public override bool Equals(object other)
        {
            return Equals(other as WeaponSaveData);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public bool Equals(WeaponSaveData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (WeponLevel != other.WeponLevel) return false;
            if (WeponEnhancementLevel != other.WeponEnhancementLevel) return false;
            return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public override int GetHashCode()
        {
            int hash = 1;
            if (WeponLevel != 0) hash ^= WeponLevel.GetHashCode();
            if (WeponEnhancementLevel != 0) hash ^= WeponEnhancementLevel.GetHashCode();
            if (_unknownFields != null)
            {
                hash ^= _unknownFields.GetHashCode();
            }
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public void WriteTo(pb::CodedOutputStream output)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            output.WriteRawMessage(this);
#else
      if (WeponLevel != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(WeponLevel);
      }
      if (WeponEnhancementLevel != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(WeponEnhancementLevel);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output)
        {
            if (WeponLevel != 0)
            {
                output.WriteRawTag(8);
                output.WriteInt32(WeponLevel);
            }
            if (WeponEnhancementLevel != 0)
            {
                output.WriteRawTag(16);
                output.WriteInt32(WeponEnhancementLevel);
            }
            if (_unknownFields != null)
            {
                _unknownFields.WriteTo(ref output);
            }
        }
#endif

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public int CalculateSize()
        {
            int size = 0;
            if (WeponLevel != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeInt32Size(WeponLevel);
            }
            if (WeponEnhancementLevel != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeInt32Size(WeponEnhancementLevel);
            }
            if (_unknownFields != null)
            {
                size += _unknownFields.CalculateSize();
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public void MergeFrom(WeaponSaveData other)
        {
            if (other == null)
            {
                return;
            }
            if (other.WeponLevel != 0)
            {
                WeponLevel = other.WeponLevel;
            }
            if (other.WeponEnhancementLevel != 0)
            {
                WeponEnhancementLevel = other.WeponEnhancementLevel;
            }
            _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public void MergeFrom(pb::CodedInputStream input)
        {
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
            input.ReadRawMessage(this);
#else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            WeponLevel = input.ReadInt32();
            break;
          }
          case 16: {
            WeponEnhancementLevel = input.ReadInt32();
            break;
          }
        }
      }
#endif
        }

#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
                        break;
                    case 8:
                        {
                            WeponLevel = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            WeponEnhancementLevel = input.ReadInt32();
                            break;
                        }
                }
            }
        }
#endif

        #region Nested types
        /// <summary>Container for nested types declared in the WeaponSaveData message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
        public static partial class Types
        {
            public enum WeaponType
            {
                [pbr::OriginalName("EWT_RIFLE")] EwtRifle = 0,
                [pbr::OriginalName("EWT_PISTOL")] EwtPistol = 1,
                [pbr::OriginalName("EWT_SHOTGUN")] EwtShotgun = 2,
            }

        }
        #endregion

    }

    #endregion

}

#endregion Designer generated code
