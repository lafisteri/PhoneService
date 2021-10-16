using System;
using System.Collections.Generic;
using System.Linq;
using PhonesCore.Models;

namespace PhonesDataLayer
{
    public class PhonesRepository : IPhonesRepository
    {
        private static List<Phone> _phones;

        static PhonesRepository()
        {
            _phones = new List<Phone>();
        }

        public List<Phone> Get()
        {
            return _phones;
        }

        public Phone Get(Guid id)
        {
            if (id != null)
            {
                return _phones.FirstOrDefault(x => x.Id == id);
            }

            return null;
        }

        public Guid Create(Phone phone)
        {
            phone.Id = Guid.NewGuid();
            _phones.Add(phone);

            return phone.Id;
        }

        public Phone Update(Phone phone)
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

        public Phone Delete(Guid id)
        {
            var oldPhone = _phones.FirstOrDefault(x => x.Id == id);
            if (oldPhone != null)
            {
                _phones.Remove(oldPhone);
            }

            return oldPhone;
        }
    }
}
