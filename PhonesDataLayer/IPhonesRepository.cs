using System;
using System.Collections.Generic;
using PhonesCore.Models;

namespace PhonesDataLayer
{
    public interface IPhonesRepository
    {
        Guid Create(Phone phone);
        Phone Delete(Guid id);
        List<Phone> Get();
        Phone Get(Guid id);
        Phone Update(Phone phone);
    }
}