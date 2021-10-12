using System.Collections.Generic;
using PhonesCore.Models;

namespace PhonesDataLayer
{
    public class PhonesRepository
    {
        private static List<Phone> _phones;

        static PhonesRepository()
        {
            _phones = new List<Phone>();
        }

        public List<Phone> GetAllPhones()
        {
            return _phones;
        }
    }
}
