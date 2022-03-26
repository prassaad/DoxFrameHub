using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.AccountAggregate.Events
{
    public class NewHubUserAddedEvent : BaseDomainEvent
    {
        public HubUser User { get; set; }
        
        public NewHubUserAddedEvent(HubUser user)
        {
            User = user;
             
        }
    }
}