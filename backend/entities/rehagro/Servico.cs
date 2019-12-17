using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Serviço
    /// </summary>
    [Table("servico", Schema = Schema.SCHEMA_REHAGRO)]
    public class Servico : EntidadeBase<Guid>
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
        /// Serviço Tipo id
        /// </summary>
        [ForeignKey(nameof(ServicoTipo))]
        public Guid ServicoTipoId { get; set; }

        /// <summary>
        /// Serviço Tipo
        /// </summary>
        public virtual ServicoTipo ServicoTipo { get; set; }

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

        public Servico()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
