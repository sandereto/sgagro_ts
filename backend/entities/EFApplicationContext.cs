using System;
using core.lib.extensions;
using entities.rehagro;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using seguranca;
using entities.logs;

namespace entities
{
    public class EFApplicationContext : IdentityDbContext<Usuario, Perfil, Guid, UsuarioClaim, UsuarioPerfil, UsuarioLogin, PerfilClaim, UsuarioToken>
    {
        public virtual DbSet<Apontamento> ApontamentoSet { get; set; }
        public virtual DbSet<ApontamentoTipo> ApontamentoTipoSet { get; set; }
        public virtual DbSet<Area> AreaSet { get; set; }
        public virtual DbSet<Cultura> CulturaSet { get; set; }
        public virtual DbSet<Equipe> EquipeSet { get; set; }
        public virtual DbSet<Fazenda> FazendaSet { get; set; }
        public virtual DbSet<FazendaTipo> FazendaTipoSet { get; set; }
        public virtual DbSet<MaturidadeSolo> MaturidadeSoloSet { get; set; }
        public virtual DbSet<Pessoa> PessoaSet { get; set; }
        public virtual DbSet<PessoaTipo> PessoaTipoSet { get; set; }
        public virtual DbSet<Safra> SafraSet { get; set; }
        public virtual DbSet<Servico> ServicoSet { get; set; }
        public virtual DbSet<ServicoTipo> ServicoTipoSet { get; set; }
        public virtual DbSet<Turno> TurnoSet { get; set; }
        public virtual DbSet<Unidade> UnidadeSet { get; set; }
        public virtual DbSet<StoredEvent> StoredEvent { get; set; }

        #region Segurança

        public virtual DbSet<Modulo> ModulosSet { get; set; }
        public virtual DbSet<PerfilModulo> PerfilModuloSet { get; set; }
        public virtual DbSet<PerfilModuloPermissao> PerfilModuloPermissaoSet { get; set; }
        public virtual DbSet<Permissao> PermissaoSet { get; set; }

        #endregion

        public EFApplicationContext(DbContextOptions<EFApplicationContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>()
                  .HasMany(e => e.Papeis)
                  .WithOne()
                  .HasForeignKey(e => e.UserId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UsuarioPerfil>()
                .HasOne(e => e.User)
                .WithMany(e => e.Papeis)
                .HasForeignKey(e => e.UserId);

            builder.Entity<UsuarioPerfil>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Papeis)
                .HasForeignKey(e => e.RoleId);

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                // Replace table names
                var currentTableName = builder.Entity(entity.Name).Metadata.Relational().TableName;
                builder.Entity(entity.Name).ToTable(currentTableName.ToLower());

                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = property.Relational().ColumnName.ToSnakeCase();
                }

                foreach (var key in entity.GetKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.Relational().Name = key.Relational().Name.ToSnakeCase();
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.Relational().Name = index.Relational().Name.ToSnakeCase();
                }
            }
        }
    }
}
