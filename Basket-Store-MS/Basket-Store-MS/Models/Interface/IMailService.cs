using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
