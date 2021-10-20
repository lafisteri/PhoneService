using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace DataLayer
{
    public class PhonesRepository : IPhonesRepository
    {
        private readonly Context _dbContext;

        public PhonesRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Phone>> GetAsync()
        {
            return await _dbContext.Phone.ToListAsync();
        }

        public async Task<Phone> GetAsync(Guid id)
        {
            if (id != null)
            {
                return await _dbContext.Phone.FirstOrDefaultAsync(x => x.Id == id);
            }

            return null;
        }

        public async Task<Guid> CreateAsync(Phone phone)
        {
            phone.Id = Guid.NewGuid();
            await _dbContext.Phone.AddAsync(phone);
            await _dbContext.SaveChangesAsync();

            return phone.Id;
        }

        public async Task<Phone> UpdateAsync(Phone phone)
        {
            _dbContext.Attach(phone);
            _dbContext.Entry(phone).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return phone;
        }

        public async Task<Phone> DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _dbContext.Phone.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

            return entity;
        }
    }
}
