﻿namespace LocknCharm.Application.DTOs.Auth
{
    public class LoginRequestDTO
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
