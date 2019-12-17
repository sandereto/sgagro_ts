using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using core.seedwork;

namespace entities.rehagro
{
    /// <summary>
    /// Tipo Fazenda
    /// </summary>
    [Table("fazenda_tipo", Schema = Schema.SCHEMA_REHAGRO)]
    public class FazendaTipo : EntidadeBase<Guid>
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

        public FazendaTipo()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
