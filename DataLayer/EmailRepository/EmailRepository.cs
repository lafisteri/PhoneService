using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EmailRepository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ContextMsSql _dbContext;

        public EmailRepository(ContextMsSql dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ConfirmEmailAsync(string email)
        {
            var emailEntity = await GetEntityByEmail(email)
                .FirstOrDefaultAsync();

            emailEntity.IsConfirmed = true;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetConfirmMessageAsync(string email)
        {
            return await GetEntityByEmail(email)
                .Select(x => x.ConfirmationString)
                .FirstOrDefaultAsync();
        }

        public async Task<int> RegisterEmailAsync(Email email)
        {
            _dbContext.Emails.Add(email);
            await _dbContext.SaveChangesAsync();

            return email.Id;
        }

        private IQueryable<Email> GetEntityByEmail(string email)
        {
            return _dbContext.Emails.Where(x => x.PostName == email);
        }
    }
}
