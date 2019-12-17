using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Fazenda
    /// </summary>
    [Table("fazenda", Schema = Schema.SCHEMA_REHAGRO)]
    public class Fazenda : EntidadeBase<Guid>
    {
        #region Properties

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(40)]
        [Required]
        public string NomeRazao { get; set; }

        /// <summary>
        /// Cnpj/Cpf
        /// </summary>
        [StringLength(40)]
        public string CpfCnpj { get; set; }

        /// <summary>
        /// Inscrição estadual
        /// </summary>
        [StringLength(10)]
        public string InscricaoEstadual { get; set; }

        /// <summary>
        /// Inscrição municipal
        /// </summary>
        [StringLength(10)]
        public string InscricaoMunicipal { get; set; }


        /// <summary>
        /// CAR
        /// </summary>
        [StringLength(10)]
        public string CAR { get; set; }

        #endregion Properties

        #region Relacionamentos

        /// <summary>
        /// FazendaTipo id
        /// </summary>
        [ForeignKey(nameof(FazendaTipo))]
        public Guid FazendaTipoId { get; set; }

        /// <summary>
        /// FazendaTipo
        /// </summary>
        public virtual FazendaTipo FazendaTipo { get; set; }

        #endregion

        #region Contructors

        public Fazenda()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
