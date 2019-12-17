using System;
using core.events;

namespace events.cadastros
{
    public class ApontamentoUpdatedEvent : Event
    {
        public ApontamentoUpdatedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
