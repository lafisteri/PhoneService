using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using BusinessLayer.DTOs;

namespace BusinessLayer.Services.PhonesService
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
