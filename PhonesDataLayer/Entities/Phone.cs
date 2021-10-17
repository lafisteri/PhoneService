using System;
using System.ComponentModel.DataAnnotations;

namespace PhonesDataLayer.Entities
{
    public class Phone
    {
        [Key]
        public Guid Id { get; set; }
        public string Model { get; set; }
        public bool IsEsim { get; set; }
        public float DisplayDiagonal { get; set; }
        public int ColorId { get; set; }
        public DateTime PresentationDay { get; set; }
    }
}
