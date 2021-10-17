using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhonesBusinessLayer.DTOs;
using PhonesCore.Models;

namespace PhonesBusinessLayer
{
    public interface IPhonesService
    {
        Task<Guid> CreatePhone(PhoneDTO phoneDTO);
        Task<Phone> DeletePhone(Guid id);
        Task<IEnumerable<Phone>> GetAllPhones();
        Task<Phone> GetById(Guid id);
        Task<Phone> UpdatePhone(Guid id, PhoneDTO phoneDTO);
    }
}
