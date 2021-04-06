using Architecture.Domain;
using Architecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Architecture.Database
{
    public sealed class MovimentacaoFinanceiraConfiguration : IEntityTypeConfiguration<MovimentacaoFinanceira>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoFinanceira> builder)
        {
            builder.ToTable(nameof(MovimentacaoFinanceira));

            builder.HasKey(mov => mov.Id);

            builder.Property(mov => mov.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(mov => mov.Tipo)
                   .HasConversion(
                        v => v.ToString(),
                        v => (TipoMovimentacaoFinanceira)Enum.Parse(typeof(TipoMovimentacaoFinanceira), v))
                .IsRequired();

            builder.Property(mov => mov.Valor).HasPrecision(16, 2).IsRequired();

            builder.Property(mov => mov.Parcelas).IsRequired();

            builder.HasOne(mov => mov.Transacao)
                   .WithOne()
                   .HasForeignKey<MovimentacaoFinanceira>("TransacaoId")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_MovimentacaoFinanceira")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}
