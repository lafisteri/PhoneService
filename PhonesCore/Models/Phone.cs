﻿using System;
using PhonesCore.Enums;

namespace PhonesCore.Models
{
    public class Phone
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public bool IsEsim { get; set; }
        public float DisplayDiagonal { get; set; }
        public Color Color { get; set; }
        public DateTime PresentationDay { get; set; }
    }
}
