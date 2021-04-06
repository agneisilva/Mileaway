using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AuthId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Auth_AuthId",
                        column: x => x.AuthId,
                        principalTable: "Auth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Operacao",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Origem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Origem",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Programa",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatusTransacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTransacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_StatusTransacao",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TipoCartao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCartao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoCartao",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Titular",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Telefone = table.Column<long>(type: "bigint", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Titular",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCartao = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TipoCartaoId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoCartao_Cartao",
                        column: x => x.TipoCartaoId,
                        principalTable: "TipoCartao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Cartao",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartaoId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    OperacaoId = table.Column<long>(type: "bigint", nullable: false),
                    OrigemId = table.Column<long>(type: "bigint", nullable: false),
                    ProgramaId = table.Column<long>(type: "bigint", nullable: false),
                    Competencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pontos = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartao_Transacao",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operacao_Transacao",
                        column: x => x.OperacaoId,
                        principalTable: "Operacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Origem_Transacao",
                        column: x => x.OrigemId,
                        principalTable: "Origem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Programa_Transacao",
                        column: x => x.ProgramaId,
                        principalTable: "Programa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusOperacao_Transacao",
                        column: x => x.StatusId,
                        principalTable: "StatusTransacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Titular_Transacao",
                        column: x => x.CartaoId,
                        principalTable: "Titular",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_Transacao",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoFinanceira",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    Parcelas = table.Column<int>(type: "int", nullable: false),
                    TransacaoId = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoFinanceira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacaoFinanceira_Transacao_TransacaoId",
                        column: x => x.TransacaoId,
                        principalTable: "Transacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_MovimentacaoFinanceira",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Auth",
                columns: new[] { "Id", "Login", "Roles", "Salt", "Senha" },
                values: new object[] { 1L, "admin", 3, "79005744-e69a-4b09-996b-08fe0b70cbb9", "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK+u88gtSXAyPDkW+hVS+dW4AmxrnaNFZks0Zzcd5xlb12wcF/q96cc4htHFzvOH9jtN98N5EBIXSvdUVnFc9kBuRTVytATZA7gITbs//hkxvNQ3eody5U9hjdH6D+AP0vVt5unZlTZ+gInn8Ze7AC5o6mn0Y3ylGO1CBJSHU9c/BcFY9oknn+XYk9ySCoDGctMqDbvOBcvSTBkKcrCzev2KnX7xYmC3yNz1Q5oPVKgnq4mc1iuldMlCxse/IDGMJB2FRdTCLV5KNS4IZ1GB+dw3tMvcEEtmXmgT2zKN5+kUkOxhlv5g1ZLgXzWjVJeKb5uZpsn3WK5kt8T+kzMoxHd5i8HxsU2uvy9GopxAnaV0WNsBPqTGkRllSxARl4ZN3hJqUla553RT49tJxbs+N03OmkYhjq+L0aKJ1AC+7G+rdjegiAQZB+3mdE7a2Pne2kYtpMoCmNMKdm9jOOVpfXJqZMQul9ltJSlAY6LPrHFUB3mw61JBNzx+sZgYN29GfDY=" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "AuthId", "Status", "Email", "PrimeiroNome", "Sobrenome" },
                values: new object[] { 1L, 1L, 1, "administrator@administrator.com", "Administrator", "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_Auth_Login",
                table: "Auth",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_NumeroCartao",
                table: "Cartao",
                column: "NumeroCartao",
                unique: true,
                filter: "[NumeroCartao] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_TipoCartaoId",
                table: "Cartao",
                column: "TipoCartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_UsuarioId",
                table: "Cartao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoFinanceira_TransacaoId",
                table: "MovimentacaoFinanceira",
                column: "TransacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoFinanceira_UsuarioId",
                table: "MovimentacaoFinanceira",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Operacao_UsuarioId",
                table: "Operacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Origem_UsuarioId",
                table: "Origem",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_UsuarioId",
                table: "Programa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusTransacao_UsuarioId",
                table: "StatusTransacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCartao_UsuarioId",
                table: "TipoCartao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Titular_CPF",
                table: "Titular",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Titular_Email",
                table: "Titular",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Titular_Telefone",
                table: "Titular",
                column: "Telefone",
                unique: true,
                filter: "[Telefone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Titular_UsuarioId",
                table: "Titular",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_CartaoId",
                table: "Transacao",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_OperacaoId",
                table: "Transacao",
                column: "OperacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_OrigemId",
                table: "Transacao",
                column: "OrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ProgramaId",
                table: "Transacao",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_StatusId",
                table: "Transacao",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_UsuarioId",
                table: "Transacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_AuthId",
                table: "Usuario",
                column: "AuthId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacaoFinanceira");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Operacao");

            migrationBuilder.DropTable(
                name: "Origem");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropTable(
                name: "StatusTransacao");

            migrationBuilder.DropTable(
                name: "Titular");

            migrationBuilder.DropTable(
                name: "TipoCartao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Auth");
        }
    }
}
