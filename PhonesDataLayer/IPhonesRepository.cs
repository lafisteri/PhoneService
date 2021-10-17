﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhonesCore.Models;

namespace PhonesDataLayer
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
