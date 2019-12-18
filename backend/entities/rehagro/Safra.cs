using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Safra
    /// </summary>
    [Table("safra", Schema = Schema.SCHEMA_REHAGRO)]
    public class Safra : EntidadeBase<Guid>
    {
        #region Properties

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(40)]
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Ano
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// Início
        /// </summary>
        public DateTime Inicio { get; set; }

        /// <summary>
        /// Fim
        /// </summary>
        public DateTime Fim { get; set; }

        /// <summary>
        /// Ativa
        /// </summary>
        public bool Ativa { get; set; }

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

        /// <summary>
        /// Cultura id
        /// </summary>
        [ForeignKey(nameof(Cultura))]
        public Guid CulturaId { get; set; }

        /// <summary>
        /// Cultura
        /// </summary>
        public virtual Cultura Cultura { get; set; }

        /// <summary>
        /// Unidade id
        /// </summary>
        [ForeignKey(nameof(Unidade))]
        public Guid UnidadeId { get; set; }

        /// <summary>
        /// Unidade
        /// </summary>
        public virtual Unidade Unidade { get; set; }

        #endregion

        #region Contructors

        public Safra()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
