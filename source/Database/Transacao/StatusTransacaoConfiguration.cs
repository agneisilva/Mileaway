using Architecture.Domain;
using Architecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Architecture.Database
{
    public sealed class StatusTransacaoConfiguration : IEntityTypeConfiguration<StatusTransacao>
    {
        public void Configure(EntityTypeBuilder<StatusTransacao> builder)
        {
            builder.ToTable(nameof(StatusTransacao));

            builder.HasKey(mov => mov.Id);

            builder.Property(mov => mov.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(mov => mov.Descricao).HasMaxLength(200).IsRequired();

            builder.HasMany(mov => mov.Transacoes)
                   .WithOne(op => op.Status)
                   .HasForeignKey("StatusId")
                   .HasConstraintName("FK_StatusOperacao_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_StatusTransacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}
