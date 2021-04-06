using Architecture.Domain;
using Architecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Architecture.Database
{
    public sealed class OperacaoConfiguration : IEntityTypeConfiguration<Operacao>
    {
        public void Configure(EntityTypeBuilder<Operacao> builder)
        {
            builder.ToTable(nameof(Operacao));

            builder.HasKey(operacao => operacao.Id);

            builder.Property(operacao => operacao.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(operacao => operacao.DataInicio).IsRequired();

            builder.Property(operacao => operacao.DataFim);

            builder.Property(mov => mov.Status)
                   .HasConversion(
                        v => v.ToString(),
                        v => (StatusOperacao)Enum.Parse(typeof(StatusOperacao), v))
                   .IsRequired();

            builder.HasMany(mov => mov.Transacoes)
                   .WithOne(op => op.Operacao)
                   .HasForeignKey("OperacaoId")
                   .HasConstraintName("FK_Operacao_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_Operacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}
