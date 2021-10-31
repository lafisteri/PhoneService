using System.IO;
using System.Threading.Tasks;
using BusinessLayer.DTOs;

namespace BusinessLayer.Services.SmtpService
{
    public class SmtpServiceMock: ISmtpService
    {
        public async Task SendMailAsync(MailDTO mailDTO)
        {
            using (var streamWritter = new StreamWriter("log.txt"))
            {
                await streamWritter.WriteLineAsync(mailDTO.Body);
            }
        }
    }
}
