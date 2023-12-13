using System;
using Grpc.Core;
using WebServer.Protos;

namespace WebServer.Service.Interface
{
    public interface ISaveService
    {
        public string SaveData(string name, Int32 level);
    }
}

