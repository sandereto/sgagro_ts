using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace events.cadastros
{
    public class ApontamentoEventHandler :
        INotificationHandler<ApontamentoCreatedEvent>,
        INotificationHandler<ApontamentoUpdatedEvent>,
        INotificationHandler<ApontamentoDeletedEvent>
    {
        public Task Handle(ApontamentoCreatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ApontamentoUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ApontamentoDeletedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
