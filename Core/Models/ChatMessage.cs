﻿using System;
namespace Core.Models
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public ConsoleColor MessageColor { get; set; }
        public string Text { get; set; }
    }
}
