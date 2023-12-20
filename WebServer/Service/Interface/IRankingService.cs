using System;
using Grpc.Core;
using WebServer.Model;

namespace WebServer.Service.Interface
{
    public interface IRankingService
    {
        public int GetRank(string userId);
    }
}

