using System;
namespace WebServer.Model
{
    public class CreateAccountParam
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }

    public class LoginParam
	{
        public string Id { get; set; }
        public string Password { get; set; }
    }
}

