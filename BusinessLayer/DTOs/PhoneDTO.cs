using System;

namespace BusinessLayer.DTOs
{
    public class PhoneDTO
    {
        public string Model { get; set; }
        public bool IsEsim { get; set; }
        public float DisplayDiagonal { get; set; }
        public string Color { get; set; }
        public DateTime PresentationDay { get; set; }
    }
}
