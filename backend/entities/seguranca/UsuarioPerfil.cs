using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using entities;
using entities.rehagro;

namespace seguranca
{
    [Table("usuario_perfil", Schema = Schema.SCHEMA_SEGURANCA)]
    public class UsuarioPerfil : IdentityUserRole<Guid>
    {
        [ForeignKey(nameof(Fazenda))]
        public Guid FazendaId { get; set; }

        /// <summary>
        /// Fazenda
        /// </summary>
        public virtual Fazenda Fazenda { get; set; }

        /// <summary>
        /// Usuário
        /// </summary>
        public virtual Usuario User { get; set; }

        /// <summary>
        /// Perfis
        /// </summary>
        public virtual Perfil Role { get; set; }
    }
}
