using System;
using Grpc.Core;
using WebServer.Model;

namespace WebServer.Service.Interface
{
    public interface ILoadService
    {
        public CharacterData LoadData(string userId);
    }
}

