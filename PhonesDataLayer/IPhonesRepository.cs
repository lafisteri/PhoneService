using System;
using System.Collections.Generic;
using PhonesCore.Models;

namespace PhonesDataLayer
{
    public interface IPhonesRepository
    {
        Guid CreatePhone(Phone phone);
        Phone DeletePhone(Guid id);
        List<Phone> GetAllPhones();
        Phone GetById(Guid id);
        Phone UpdatePhone(Phone phone);
    }
}