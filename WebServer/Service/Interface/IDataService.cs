﻿using System;
using Grpc.Core;
using WebServer.Model;

namespace WebServer.Service.Interface
{
    public interface IDataService
    {
        public bool SaveCharacterData(string userId, CharacterData data);
        public CharacterData LoadCharacterData(string userId);
    }
}

