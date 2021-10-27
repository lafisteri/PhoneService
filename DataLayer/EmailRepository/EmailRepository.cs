using System.Threading.Tasks;
using Core.Models;

namespace DataLayer.EmailRepository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ContextMsSql _dbContext;

        public EmailRepository(ContextMsSql dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> RegisterEmailAsync(Email email)
        {
            _dbContext.Emails.Add(email);
            await _dbContext.SaveChangesAsync();

            return email.Id;
        }
    }
}
