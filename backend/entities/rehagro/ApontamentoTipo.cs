using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Apontamento
    /// </summary>
    [Table("apontamento_tipo", Schema = Schema.SCHEMA_REHAGRO)]
    public partial class ApontamentoTipo : EntidadeBase<Guid>
    {
        #region Properties

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(40)]
        [Required]
        public string Nome { get; set; }

        #endregion Properties

        #region Contructors

        public ApontamentoTipo()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }

}
