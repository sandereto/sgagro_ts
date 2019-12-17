using System;
using core.events;

namespace events.cadastros
{
    public class ApontamentoDeletedEvent : Event
    {
        public ApontamentoDeletedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
