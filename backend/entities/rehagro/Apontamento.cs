using System;
using System.ComponentModel.DataAnnotations.Schema;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Apontamento
    /// </summary>
    [Table("apontamento", Schema = Schema.SCHEMA_REHAGRO)]
    public partial class Apontamento : EntidadeBase<Guid>
    {
        #region Properties

        #endregion Properties

        #region Relacionamentos

        /// <summary>
        /// Apontamento id
        /// </summary>
        [ForeignKey(nameof(ApontamentoTipo))]
        public Guid ApontamentoTipoId { get; set; }

        /// <summary>
        /// Apontamento
        /// </summary>
        public virtual ApontamentoTipo ApontamentoTipo { get; set; }

        #endregion

        #region Contructors

        public Apontamento()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }

}
