using System.Threading.Tasks;
using Core.Models;

namespace DataLayer.EmailRepository
{
    public interface IEmailRepository
    {
        Task<int> RegisterEmailAsync(Email email);
        Task<string> GetConfirmMessageAsync(string email);
        Task ConfirmEmailAsync(string email);
    }
}
