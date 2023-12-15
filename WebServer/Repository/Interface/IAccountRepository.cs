﻿using System;
using WebServer.Model;
using WebServer.Protos;

namespace WebServer.Repository.Interface
{
	public interface IAccountRepository
	{
		public bool CreateAccount(string inputId, string inputPwd);
		public bool IsEnrolledAccount(string inputId);
		public bool IsCorrectPassword(string inputId, string inputPwd);
        public CharacterData GetUserCharacterData(string userId);
		

    }
}

