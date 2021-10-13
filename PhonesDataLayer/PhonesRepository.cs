using System;
using System.Collections.Generic;
using System.Linq;
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

        public Phone GetById(Guid id)
        {
            return _phones.FirstOrDefault(x => x.Id == id);
        }

        public Guid CreatePhone(Phone phone)
        {
            phone.Id = Guid.NewGuid();
            _phones.Add(phone);

            return phone.Id;
        }

        public Phone UpdatePhone(Phone phone)
        {
            var oldPhone = _phones.FirstOrDefault(x => x.Id == phone.Id);
            if (oldPhone != null)
            {
                var index = _phones.IndexOf(oldPhone);

                _phones[index] = phone;

                return phone;
            }

            return null;
        }

        public Phone DeletePhone(Guid id)
        {
            var oldPhone = _phones.FirstOrDefault(x => x.Id == id);
            _phones.Remove(oldPhone);

            return oldPhone;
        }
    }
}
