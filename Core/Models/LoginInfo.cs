﻿namespace Core.Models
{
    public class LoginInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Login}:{Password}";
        }
    }
}
