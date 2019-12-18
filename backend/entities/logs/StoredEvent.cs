using System;
using System.ComponentModel.DataAnnotations.Schema;
using core.seedwork;

namespace entities.logs
{
    /// <summary>
    /// Armazena os eventos
    /// </summary>
    [Table("stored_event", Schema = Schema.SCHEMA_LOGS)]
    public class StoredEvent : EntidadeBase<Guid>
    {
        #region Properties

        public Guid AggregateId { get; set; }

        public string Data { get; set; }

        public string Usuario { get; set; }

        public string MessageType { get; set; }

        #endregion Properties

        #region Contructors

        public StoredEvent()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
