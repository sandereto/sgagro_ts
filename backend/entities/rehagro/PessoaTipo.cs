using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Tipo Pessoa
    /// </summary>
    [Table("pessoa_tipo", Schema = Schema.SCHEMA_REHAGRO)]
    public class PessoaTipo : EntidadeBase<Guid>
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

        public PessoaTipo()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
