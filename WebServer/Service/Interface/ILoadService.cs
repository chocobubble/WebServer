using System;
using Grpc.Core;
using WebServer.Protos;

namespace WebServer.Service.Interface
{
    public interface ILoadService
    {
        public string LoadData(string userId);
    }
}

