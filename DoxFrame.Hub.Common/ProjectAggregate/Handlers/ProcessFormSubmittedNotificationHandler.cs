using Ardalis.GuardClauses;
using DoxFrame.Hub.Core.Interfaces;
using DoxFrame.Hub.Core.ProjectAggregate.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Core.ProjectAggregate.Handlers
{
    public class ProcessFormSubmittedNotificationHandler : INotificationHandler<ProcessFormSubmittedEvent>
    {
        private readonly ICamundaClient _engineRequest;

        // In a REAL app you might want to use the Outbox pattern and a command/queue here...
        public ProcessFormSubmittedNotificationHandler(ICamundaClient engineRequest)
        {
            _engineRequest = engineRequest;
        }
        public Task Handle(ProcessFormSubmittedEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));
            return _engineRequest.SendRequestAsync();
        }
    }
}
