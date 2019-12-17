using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using core.seedwork;
using seguranca;

namespace entities.rehagro
{
    /// <summary>
    /// Pessoa
    /// </summary>
    [Table("pessoa", Schema = Schema.SCHEMA_REHAGRO)]
    public class Pessoa : EntidadeBase<Guid>
    {
        #region Properties

        /// <summary>
        /// Nome
        /// </summary>
        [StringLength(40)]
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Cnpj/Cpf
        /// </summary>
        [StringLength(40)]
        public string CpfCnpj { get; set; }

        /// <summary>
        /// Rg
        /// </summary>
        [StringLength(11)]
        public string Rg { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public DateTime? DataNascimento { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        [StringLength(40)]
        [Required]
        public string Sexo { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        [StringLength(40)]
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [StringLength(12)]
        public string Telefone { get; set; }

        /// <summary>
        /// Ativo
        /// </summary>
        [Required]
        public bool Ativo { get; set; }

        #endregion Properties

        #region Relacionamentos

        /// <summary>
        /// Usuario Id
        /// </summary>
        [ForeignKey(nameof(FazendaTipo))]
        public Guid? UsuarioId { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        public virtual Usuario Usuario { get; set; }

        /// <summary>
        /// Pessoa Tipo Id
        /// </summary>
        [ForeignKey(nameof(PessoaTipo))]
        public Guid PessoaTipoId { get; set; }

        /// <summary>
        /// Pessoa Tipo
        /// </summary>
        public virtual PessoaTipo PessoaTipo { get; set; }

        #endregion

        #region Contructors

        public Pessoa()
        {
            Id = Guid.NewGuid();
        }

        #endregion Contructors
    }
}
