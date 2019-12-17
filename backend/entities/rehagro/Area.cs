using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Area
    /// </summary>
    [Table("area", Schema = Schema.SCHEMA_REHAGRO)]
    public class Area : EntidadeBase<Guid>
    {
        #region Properties

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(40)]
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Area
        /// </summary>
        public decimal AreaHa { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(500)]
        public string Observacao { get; set; }

        /// <summary>
        /// Agrupador
        /// </summary>
        public string Agrupador { get; set; }

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

        /// <summary>
        /// Fazenda id
        /// </summary>
        [ForeignKey(nameof(MaturidadeSolo))]
        public Guid MaturidadeSoloId { get; set; }

        /// <summary>
        /// Maturidade Solo
        /// </summary>
        public virtual MaturidadeSolo MaturidadeSolo { get; set; }

        #endregion

        #region Contructors

        public Area()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
