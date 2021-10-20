using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace DataLayer
{
    public interface IPhonesRepository
    {
        Task<Guid> CreateAsync(Phone phone);
        Task<Phone> DeleteAsync(Guid id);
        Task<List<Phone>> GetAsync();
        Task<Phone> GetAsync(Guid id);
        Task<Phone> UpdateAsync(Phone phone);
    }
}
