using System.Threading.Tasks;
using Core.Models;

namespace DataLayer.EmailRepository
{
    public interface IEmailRepository
    {
        Task<int> RegisterEmailAsync(Email email);
    }
}
