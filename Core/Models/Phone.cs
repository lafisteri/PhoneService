using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

namespace Core.Models
{
    public class Phone
    {

        public Guid Id { get; set; }
        public string Model { get; set; }
        public bool IsEsim { get; set; }
        public float DisplayDiagonal { get; set; }
        [Column("ColorId")]
        public Color Color { get; set; }
        public DateTime PresentationDay { get; set; }
    }
}
