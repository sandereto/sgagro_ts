using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "logs");

            migrationBuilder.EnsureSchema(
                name: "rehagro");

            migrationBuilder.EnsureSchema(
                name: "seguranca");

            migrationBuilder.CreateTable(
                name: "stored_event",
                schema: "logs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    aggregate_id = table.Column<Guid>(nullable: false),
                    data = table.Column<string>(nullable: true),
                    usuario = table.Column<string>(nullable: true),
                    message_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stored_event", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "apontamento_tipo",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apontamento_tipo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fazenda_tipo",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fazenda_tipo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetroles",
                schema: "seguranca",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_alteracao = table.Column<DateTime>(nullable: false),
                    desativado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusers",
                schema: "seguranca",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    user_name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    password_hash = table.Column<string>(nullable: true),
                    security_stamp = table.Column<string>(nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    cpj_cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_alteracao = table.Column<DateTime>(nullable: false),
                    desativado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "modulo",
                schema: "seguranca",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    desativado = table.Column<bool>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_modulo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissao",
                schema: "seguranca",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    desativado = table.Column<bool>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "apontamento",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    apontamento_tipo_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apontamento", x => x.id);
                    table.ForeignKey(
                        name: "fk_apontamento_apontamento_tipo_apontamento_tipo_id",
                        column: x => x.apontamento_tipo_id,
                        principalSchema: "rehagro",
                        principalTable: "apontamento_tipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fazenda",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome_razao = table.Column<string>(maxLength: 40, nullable: false),
                    cpf_cnpj = table.Column<string>(maxLength: 40, nullable: true),
                    inscricao_estadual = table.Column<string>(maxLength: 10, nullable: true),
                    inscricao_municipal = table.Column<string>(maxLength: 10, nullable: true),
                    car = table.Column<string>(maxLength: 10, nullable: true),
                    fazenda_tipo_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fazenda", x => x.id);
                    table.ForeignKey(
                        name: "fk_fazenda_fazenda_tipo_fazenda_tipo_id",
                        column: x => x.fazenda_tipo_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda_tipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetroleclaims",
                schema: "seguranca",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    role_id = table.Column<Guid>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroleclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetroleclaims_aspnetroles_role_id",
                        column: x => x.role_id,
                        principalSchema: "seguranca",
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserclaims",
                schema: "seguranca",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    user_id = table.Column<Guid>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetuserclaims_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalSchema: "seguranca",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserlogins",
                schema: "seguranca",
                columns: table => new
                {
                    login_provider = table.Column<string>(nullable: false),
                    provider_key = table.Column<string>(nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserlogins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_aspnetuserlogins_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalSchema: "seguranca",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetusertokens",
                schema: "seguranca",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    login_provider = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusertokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_aspnetusertokens_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalSchema: "seguranca",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfil_modulo",
                schema: "seguranca",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    desativado = table.Column<bool>(nullable: false),
                    perfil_id = table.Column<Guid>(nullable: false),
                    modulo_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_perfil_modulo", x => x.id);
                    table.ForeignKey(
                        name: "fk_perfil_modulo_modulo_modulo_id",
                        column: x => x.modulo_id,
                        principalSchema: "seguranca",
                        principalTable: "modulo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_perfil_modulo_aspnetroles_perfil_id",
                        column: x => x.perfil_id,
                        principalSchema: "seguranca",
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cultura",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cultura", x => x.id);
                    table.ForeignKey(
                        name: "fk_cultura_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipe",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    ativo = table.Column<bool>(nullable: false),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_equipe", x => x.id);
                    table.ForeignKey(
                        name: "fk_equipe_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "maturidade_solo",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maturidade_solo", x => x.id);
                    table.ForeignKey(
                        name: "fk_maturidade_solo_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pessoa_tipo",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoa_tipo", x => x.id);
                    table.ForeignKey(
                        name: "fk_pessoa_tipo_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servico_tipo",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servico_tipo", x => x.id);
                    table.ForeignKey(
                        name: "fk_servico_tipo_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "turno",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_turno", x => x.id);
                    table.ForeignKey(
                        name: "fk_turno_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "unidade",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unidade", x => x.id);
                    table.ForeignKey(
                        name: "fk_unidade_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aspnetuserroles",
                schema: "seguranca",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserroles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetroles_role_id",
                        column: x => x.role_id,
                        principalSchema: "seguranca",
                        principalTable: "aspnetroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetusers_user_id",
                        column: x => x.user_id,
                        principalSchema: "seguranca",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "modulo_permissao",
                schema: "seguranca",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    desativado = table.Column<bool>(nullable: false),
                    perfil_modulo_id = table.Column<Guid>(nullable: false),
                    permissao_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_modulo_permissao", x => x.id);
                    table.ForeignKey(
                        name: "fk_modulo_permissao_perfil_modulo_perfil_modulo_id",
                        column: x => x.perfil_modulo_id,
                        principalSchema: "seguranca",
                        principalTable: "perfil_modulo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_modulo_permissao_permissao_permissao_id",
                        column: x => x.permissao_id,
                        principalSchema: "seguranca",
                        principalTable: "permissao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "area",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    area_ha = table.Column<decimal>(nullable: false),
                    observacao = table.Column<string>(maxLength: 500, nullable: true),
                    agrupador = table.Column<string>(nullable: true),
                    ativo = table.Column<bool>(nullable: false),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false),
                    maturidade_solo_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_area", x => x.id);
                    table.ForeignKey(
                        name: "fk_area_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_area_maturidade_solo_maturidade_solo_id",
                        column: x => x.maturidade_solo_id,
                        principalSchema: "rehagro",
                        principalTable: "maturidade_solo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    cpf_cnpj = table.Column<string>(maxLength: 40, nullable: true),
                    rg = table.Column<string>(maxLength: 11, nullable: true),
                    data_nascimento = table.Column<DateTime>(nullable: true),
                    sexo = table.Column<string>(maxLength: 40, nullable: false),
                    nacionalidade = table.Column<string>(maxLength: 40, nullable: true),
                    email = table.Column<string>(maxLength: 200, nullable: true),
                    telefone = table.Column<string>(maxLength: 12, nullable: true),
                    ativo = table.Column<bool>(nullable: false),
                    usuario_id = table.Column<Guid>(nullable: true),
                    pessoa_tipo_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoa", x => x.id);
                    table.ForeignKey(
                        name: "fk_pessoa_pessoa_tipo_pessoa_tipo_id",
                        column: x => x.pessoa_tipo_id,
                        principalSchema: "rehagro",
                        principalTable: "pessoa_tipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pessoa_asp_net_users_usuario_id",
                        column: x => x.usuario_id,
                        principalSchema: "seguranca",
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "servico",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    servico_tipo_id = table.Column<Guid>(nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servico", x => x.id);
                    table.ForeignKey(
                        name: "fk_servico_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servico_servico_tipo_servico_tipo_id",
                        column: x => x.servico_tipo_id,
                        principalSchema: "rehagro",
                        principalTable: "servico_tipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "safra",
                schema: "rehagro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    nome = table.Column<string>(maxLength: 40, nullable: false),
                    ano = table.Column<int>(nullable: false),
                    inicio = table.Column<DateTime>(nullable: false),
                    fim = table.Column<DateTime>(nullable: false),
                    ativa = table.Column<bool>(nullable: false),
                    fazenda_id = table.Column<Guid>(nullable: false),
                    cultura_id = table.Column<Guid>(nullable: false),
                    unidade_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_safra", x => x.id);
                    table.ForeignKey(
                        name: "fk_safra_cultura_cultura_id",
                        column: x => x.cultura_id,
                        principalSchema: "rehagro",
                        principalTable: "cultura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_safra_fazenda_fazenda_id",
                        column: x => x.fazenda_id,
                        principalSchema: "rehagro",
                        principalTable: "fazenda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_safra_unidade_unidade_id",
                        column: x => x.unidade_id,
                        principalSchema: "rehagro",
                        principalTable: "unidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_apontamento_apontamento_tipo_id",
                schema: "rehagro",
                table: "apontamento",
                column: "apontamento_tipo_id");

            migrationBuilder.CreateIndex(
                name: "ix_area_fazenda_id",
                schema: "rehagro",
                table: "area",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_area_maturidade_solo_id",
                schema: "rehagro",
                table: "area",
                column: "maturidade_solo_id");

            migrationBuilder.CreateIndex(
                name: "ix_cultura_fazenda_id",
                schema: "rehagro",
                table: "cultura",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_equipe_fazenda_id",
                schema: "rehagro",
                table: "equipe",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_fazenda_fazenda_tipo_id",
                schema: "rehagro",
                table: "fazenda",
                column: "fazenda_tipo_id");

            migrationBuilder.CreateIndex(
                name: "ix_maturidade_solo_fazenda_id",
                schema: "rehagro",
                table: "maturidade_solo",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_pessoa_pessoa_tipo_id",
                schema: "rehagro",
                table: "pessoa",
                column: "pessoa_tipo_id");

            migrationBuilder.CreateIndex(
                name: "ix_pessoa_usuario_id",
                schema: "rehagro",
                table: "pessoa",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_pessoa_tipo_fazenda_id",
                schema: "rehagro",
                table: "pessoa_tipo",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_safra_cultura_id",
                schema: "rehagro",
                table: "safra",
                column: "cultura_id");

            migrationBuilder.CreateIndex(
                name: "ix_safra_fazenda_id",
                schema: "rehagro",
                table: "safra",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_safra_unidade_id",
                schema: "rehagro",
                table: "safra",
                column: "unidade_id");

            migrationBuilder.CreateIndex(
                name: "ix_servico_fazenda_id",
                schema: "rehagro",
                table: "servico",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_servico_servico_tipo_id",
                schema: "rehagro",
                table: "servico",
                column: "servico_tipo_id");

            migrationBuilder.CreateIndex(
                name: "ix_servico_tipo_fazenda_id",
                schema: "rehagro",
                table: "servico_tipo",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_turno_fazenda_id",
                schema: "rehagro",
                table: "turno",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_unidade_fazenda_id",
                schema: "rehagro",
                table: "unidade",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetroleclaims_role_id",
                schema: "seguranca",
                table: "aspnetroleclaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "role_name_index",
                schema: "seguranca",
                table: "aspnetroles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserclaims_user_id",
                schema: "seguranca",
                table: "aspnetuserclaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserlogins_user_id",
                schema: "seguranca",
                table: "aspnetuserlogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserroles_fazenda_id",
                schema: "seguranca",
                table: "aspnetuserroles",
                column: "fazenda_id");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserroles_role_id",
                schema: "seguranca",
                table: "aspnetuserroles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "email_index",
                schema: "seguranca",
                table: "aspnetusers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "user_name_index",
                schema: "seguranca",
                table: "aspnetusers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_modulo_permissao_perfil_modulo_id",
                schema: "seguranca",
                table: "modulo_permissao",
                column: "perfil_modulo_id");

            migrationBuilder.CreateIndex(
                name: "ix_modulo_permissao_permissao_id",
                schema: "seguranca",
                table: "modulo_permissao",
                column: "permissao_id");

            migrationBuilder.CreateIndex(
                name: "ix_perfil_modulo_modulo_id",
                schema: "seguranca",
                table: "perfil_modulo",
                column: "modulo_id");

            migrationBuilder.CreateIndex(
                name: "ix_perfil_modulo_perfil_id",
                schema: "seguranca",
                table: "perfil_modulo",
                column: "perfil_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stored_event",
                schema: "logs");

            migrationBuilder.DropTable(
                name: "apontamento",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "area",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "equipe",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "pessoa",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "safra",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "servico",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "turno",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "aspnetroleclaims",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "aspnetuserclaims",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "aspnetuserlogins",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "aspnetuserroles",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "aspnetusertokens",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "modulo_permissao",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "apontamento_tipo",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "maturidade_solo",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "pessoa_tipo",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "cultura",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "unidade",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "servico_tipo",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "aspnetusers",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "perfil_modulo",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "permissao",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "fazenda",
                schema: "rehagro");

            migrationBuilder.DropTable(
                name: "modulo",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "aspnetroles",
                schema: "seguranca");

            migrationBuilder.DropTable(
                name: "fazenda_tipo",
                schema: "rehagro");
        }
    }
}
