using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using entities;
using core.seedwork;

namespace seguranca
{
    /// <summary>
    /// Modulo
    /// </summary>
    [Table("modulo", Schema = Schema.SCHEMA_SEGURANCA)]
    public class Modulo : EntidadeBase
    {
        #region Properties

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Codigo
        /// </summary>
        public string Codigo { get; set; }

        #endregion

        #region Contructors

        public Modulo()
        {

        }

        #endregion
    }
}
