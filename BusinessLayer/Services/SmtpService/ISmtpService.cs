using System.Threading.Tasks;
using BusinessLayer.DTOs;

namespace BusinessLayer.Services.SmtpService
{
    public interface ISmtpService
    {
        Task SendMailAsync(MailDTO mailDTO);
    }
}
