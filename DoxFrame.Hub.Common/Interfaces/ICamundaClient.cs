using System.Threading.Tasks;

namespace DoxFrame.Hub.Core.Interfaces
{
    public interface ICamundaClient
    {
        Task SendRequestAsync();
    }
}
