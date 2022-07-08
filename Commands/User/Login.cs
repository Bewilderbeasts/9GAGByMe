﻿using FunnyImages.Commands;
using System;

namespace FunnyImages.Commands.User
{
    public class Login : ICommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}