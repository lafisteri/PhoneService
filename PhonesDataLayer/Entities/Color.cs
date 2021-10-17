﻿using System.ComponentModel.DataAnnotations;

namespace PhonesDataLayer.Entities
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
