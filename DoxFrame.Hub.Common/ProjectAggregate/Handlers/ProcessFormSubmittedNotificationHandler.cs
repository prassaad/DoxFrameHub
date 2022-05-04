using Ardalis.GuardClauses;
using DoxFrame.Hub.Core.Interfaces;
using DoxFrame.Hub.Core.ProjectAggregate.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Core.ProjectAggregate.Handlers
{
    public class WorkflowFormSubmittedNotificationHandler : INotificationHandler<WorkflowFormSubmittedEvent>
    {
        private readonly ICamundaClient _engineRequest;

        // In a REAL app you might want to use the Outbox pattern and a command/queue here...
        public WorkflowFormSubmittedNotificationHandler(ICamundaClient engineRequest)
        {
            _engineRequest = engineRequest;
        }
        public Task Handle(WorkflowFormSubmittedEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));
            return _engineRequest.SendRequestAsync();
        }
    }
}
