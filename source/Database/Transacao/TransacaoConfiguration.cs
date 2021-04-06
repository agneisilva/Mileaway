using Architecture.Domain;
using Architecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Architecture.Database
{
    public sealed class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable(nameof(Transacao));

            builder.HasKey(mov => mov.Id);

            builder.Property(mov => mov.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(mov => mov.Competencia).IsRequired();

            builder.Property(mov => mov.Pontos).IsRequired();

            builder.HasOne(mov => mov.Cartao)
                   .WithMany(op => op.Transacoes)
                   .HasForeignKey("CartaoId")
                   .HasConstraintName("FK_Cartao_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(mov => mov.Titular)
                   .WithMany(op => op.Transacoes)
                   .HasForeignKey("CartaoId")
                   .HasConstraintName("FK_Titular_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(mov => mov.Status)
                   .WithMany(op => op.Transacoes)
                   .HasForeignKey("StatusId")
                   .HasConstraintName("FK_StatusOperacao_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(mov => mov.Operacao)
                   .WithMany(op => op.Transacoes)
                   .HasForeignKey("OperacaoId")
                   .HasConstraintName("FK_Operacao_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(mov => mov.Origem)
                   .WithMany(or => or.Transacoes)
                   .HasForeignKey("OrigemId")
                   .HasConstraintName("FK_Origem_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(mov => mov.Programa)
                   .WithMany(or => or.Transacoes)
                   .HasForeignKey("ProgramaId")
                   .HasConstraintName("FK_Programa_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}
