using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Equipe
    /// </summary>
    [Table("equipe", Schema = Schema.SCHEMA_REHAGRO)]
    public class Equipe : EntidadeBase<Guid>
    {
        #region Properties

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(40)]
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Ativo
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Data criação
        /// </summary>
        public DateTime DataCriacao { get; set; }

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

        public Equipe()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
