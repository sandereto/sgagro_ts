using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Maturidade Solo
    /// </summary>
    [Table("maturidade_solo", Schema = Schema.SCHEMA_REHAGRO)]
    public class MaturidadeSolo : EntidadeBase<Guid>
    {
        #region Properties

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(40)]
        [Required]
        public string Nome { get; set; }

        #endregion Properties

        #region Relacionamentos

        /// <summary>
        /// Fazenda id
        /// </summary>
        [ForeignKey(nameof(Fazenda))]
        public Guid FazendaId { get; set; }

        /// <summary>
        /// Fazenda
        /// </summary>
        public virtual Fazenda Fazenda { get; set; }

        #endregion

        #region Contructors

        public MaturidadeSolo()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
