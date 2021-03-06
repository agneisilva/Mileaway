// <auto-generated />
using System;
using Architecture.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Architecture.Database.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210504105349_PasswordResetToken")]
    partial class PasswordResetToken
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Architecture.Domain.Auth", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResetToken")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Auth");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Login = "admin",
                            Roles = 3,
                            Salt = "79005744-e69a-4b09-996b-08fe0b70cbb9",
                            Senha = "O34uMN1Vho2IYcSM7nlXEqn57RZ8VEUsJwH++sFr0i3MSHJVx8J3PQGjhLR3s5i4l0XWUnCnymQ/EbRmzvLy8uMWREZu7vZI+BqebjAl5upYKMMQvlEcBeyLcRRTTBpYpv80m/YCZQmpig4XFVfIViLLZY/Kr5gBN5dkQf25rK+u88gtSXAyPDkW+hVS+dW4AmxrnaNFZks0Zzcd5xlb12wcF/q96cc4htHFzvOH9jtN98N5EBIXSvdUVnFc9kBuRTVytATZA7gITbs//hkxvNQ3eody5U9hjdH6D+AP0vVt5unZlTZ+gInn8Ze7AC5o6mn0Y3ylGO1CBJSHU9c/BcFY9oknn+XYk9ySCoDGctMqDbvOBcvSTBkKcrCzev2KnX7xYmC3yNz1Q5oPVKgnq4mc1iuldMlCxse/IDGMJB2FRdTCLV5KNS4IZ1GB+dw3tMvcEEtmXmgT2zKN5+kUkOxhlv5g1ZLgXzWjVJeKb5uZpsn3WK5kt8T+kzMoxHd5i8HxsU2uvy9GopxAnaV0WNsBPqTGkRllSxARl4ZN3hJqUla553RT49tJxbs+N03OmkYhjq+L0aKJ1AC+7G+rdjegiAQZB+3mdE7a2Pne2kYtpMoCmNMKdm9jOOVpfXJqZMQul9ltJSlAY6LPrHFUB3mw61JBNzx+sZgYN29GfDY="
                        });
                });

            modelBuilder.Entity("Architecture.Domain.Cartao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("TipoCartaoId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TipoCartaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cartao");
                });

            modelBuilder.Entity("Architecture.Domain.MovimentacaoFinanceira", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Parcelas")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransacaoId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Valor")
                        .HasPrecision(16, 2)
                        .HasColumnType("decimal(16,2)");

                    b.HasKey("Id");

                    b.HasIndex("TransacaoId")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("MovimentacaoFinanceira");
                });

            modelBuilder.Entity("Architecture.Domain.Operacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Operacao");
                });

            modelBuilder.Entity("Architecture.Domain.Origem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Origem");
                });

            modelBuilder.Entity("Architecture.Domain.Programa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Programa");
                });

            modelBuilder.Entity("Architecture.Domain.StatusTransacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("StatusTransacao");
                });

            modelBuilder.Entity("Architecture.Domain.TipoCartao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TipoCartao");
                });

            modelBuilder.Entity("Architecture.Domain.Titular", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Titular");
                });

            modelBuilder.Entity("Architecture.Domain.Transacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CartaoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Competencia")
                        .HasColumnType("datetime2");

                    b.Property<long>("OperacaoId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrigemId")
                        .HasColumnType("bigint");

                    b.Property<int>("Pontos")
                        .HasColumnType("int");

                    b.Property<long>("ProgramaId")
                        .HasColumnType("bigint");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.HasIndex("OperacaoId");

                    b.HasIndex("OrigemId");

                    b.HasIndex("ProgramaId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("Architecture.Domain.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AuthId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthId")
                        .IsUnique();

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AuthId = 1L,
                            Status = 1
                        });
                });

            modelBuilder.Entity("Architecture.Domain.Cartao", b =>
                {
                    b.HasOne("Architecture.Domain.TipoCartao", "Tipo")
                        .WithMany("Cartoes")
                        .HasForeignKey("TipoCartaoId")
                        .HasConstraintName("FK_TipoCartao_Cartao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_Cartao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Architecture.Domain.Nome", "Nome", b1 =>
                        {
                            b1.Property<long>("CartaoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("PrimeiroNome");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("CartaoId");

                            b1.ToTable("Cartao");

                            b1.WithOwner()
                                .HasForeignKey("CartaoId");
                        });

                    b.OwnsOne("Architecture.Domain.NumeroCartao", "Numero", b1 =>
                        {
                            b1.Property<long>("CartaoId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)")
                                .HasColumnName("NumeroCartao");

                            b1.HasKey("CartaoId");

                            b1.HasIndex("Numero")
                                .IsUnique()
                                .HasFilter("[NumeroCartao] IS NOT NULL");

                            b1.ToTable("Cartao");

                            b1.WithOwner()
                                .HasForeignKey("CartaoId");
                        });

                    b.Navigation("Nome");

                    b.Navigation("Numero");

                    b.Navigation("Tipo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.MovimentacaoFinanceira", b =>
                {
                    b.HasOne("Architecture.Domain.Transacao", "Transacao")
                        .WithOne()
                        .HasForeignKey("Architecture.Domain.MovimentacaoFinanceira", "TransacaoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_MovimentacaoFinanceira")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Transacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.Operacao", b =>
                {
                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_Operacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.Origem", b =>
                {
                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_Origem")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.Programa", b =>
                {
                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_Programa")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.StatusTransacao", b =>
                {
                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_StatusTransacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.TipoCartao", b =>
                {
                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_TipoCartao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.Titular", b =>
                {
                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_Titular")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Architecture.Domain.CPF", "CPF", b1 =>
                        {
                            b1.Property<long>("TitularId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)")
                                .HasColumnName("CPF");

                            b1.HasKey("TitularId");

                            b1.HasIndex("Numero")
                                .IsUnique()
                                .HasFilter("[CPF] IS NOT NULL");

                            b1.ToTable("Titular");

                            b1.WithOwner()
                                .HasForeignKey("TitularId");
                        });

                    b.OwnsOne("Architecture.Domain.Email", "Email", b1 =>
                        {
                            b1.Property<long>("TitularId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)")
                                .HasColumnName("Email");

                            b1.HasKey("TitularId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasFilter("[Email] IS NOT NULL");

                            b1.ToTable("Titular");

                            b1.WithOwner()
                                .HasForeignKey("TitularId");
                        });

                    b.OwnsOne("Architecture.Domain.Nome", "Nome", b1 =>
                        {
                            b1.Property<long>("TitularId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("PrimeiroNome");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("TitularId");

                            b1.ToTable("Titular");

                            b1.WithOwner()
                                .HasForeignKey("TitularId");
                        });

                    b.OwnsOne("Architecture.Domain.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<long>("TitularId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<long>("Numero")
                                .HasColumnType("bigint")
                                .HasColumnName("Telefone");

                            b1.HasKey("TitularId");

                            b1.HasIndex("Numero")
                                .IsUnique()
                                .HasFilter("[Telefone] IS NOT NULL");

                            b1.ToTable("Titular");

                            b1.WithOwner()
                                .HasForeignKey("TitularId");
                        });

                    b.Navigation("CPF");

                    b.Navigation("Email");

                    b.Navigation("Nome");

                    b.Navigation("Telefone");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.Transacao", b =>
                {
                    b.HasOne("Architecture.Domain.Cartao", "Cartao")
                        .WithMany("Transacoes")
                        .HasForeignKey("CartaoId")
                        .HasConstraintName("FK_Cartao_Transacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Architecture.Domain.Titular", "Titular")
                        .WithMany("Transacoes")
                        .HasForeignKey("CartaoId")
                        .HasConstraintName("FK_Titular_Transacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Architecture.Domain.Operacao", "Operacao")
                        .WithMany("Transacoes")
                        .HasForeignKey("OperacaoId")
                        .HasConstraintName("FK_Operacao_Transacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Architecture.Domain.Origem", "Origem")
                        .WithMany("Transacoes")
                        .HasForeignKey("OrigemId")
                        .HasConstraintName("FK_Origem_Transacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Architecture.Domain.Programa", "Programa")
                        .WithMany("Transacoes")
                        .HasForeignKey("ProgramaId")
                        .HasConstraintName("FK_Programa_Transacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Architecture.Domain.StatusTransacao", "Status")
                        .WithMany("Transacoes")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_StatusOperacao_Transacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Architecture.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_Usuario_Transacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cartao");

                    b.Navigation("Operacao");

                    b.Navigation("Origem");

                    b.Navigation("Programa");

                    b.Navigation("Status");

                    b.Navigation("Titular");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Architecture.Domain.Usuario", b =>
                {
                    b.HasOne("Architecture.Domain.Auth", "Auth")
                        .WithOne()
                        .HasForeignKey("Architecture.Domain.Usuario", "AuthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Architecture.Domain.Email", "Email", b1 =>
                        {
                            b1.Property<long>("UsuarioId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("nvarchar(300)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasFilter("[Email] IS NOT NULL");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");

                            b1.HasData(
                                new
                                {
                                    UsuarioId = 1L,
                                    Value = "administrator@administrator.com"
                                });
                        });

                    b.OwnsOne("Architecture.Domain.Nome", "Name", b1 =>
                        {
                            b1.Property<long>("UsuarioId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("PrimeiroNome");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");

                            b1.HasData(
                                new
                                {
                                    UsuarioId = 1L,
                                    PrimeiroNome = "Administrator",
                                    Sobrenome = "Administrator"
                                });
                        });

                    b.Navigation("Auth");

                    b.Navigation("Email");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Architecture.Domain.Cartao", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("Architecture.Domain.Operacao", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("Architecture.Domain.Origem", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("Architecture.Domain.Programa", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("Architecture.Domain.StatusTransacao", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("Architecture.Domain.TipoCartao", b =>
                {
                    b.Navigation("Cartoes");
                });

            modelBuilder.Entity("Architecture.Domain.Titular", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
