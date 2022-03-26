using System.Threading.Tasks;

namespace DoxFrame.Hub.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
 
