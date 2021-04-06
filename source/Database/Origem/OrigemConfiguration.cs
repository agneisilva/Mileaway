using Architecture.Domain;
using Architecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Architecture.Database
{
    public sealed class OrigemConfiguration : IEntityTypeConfiguration<Origem>
    {
        public void Configure(EntityTypeBuilder<Origem> builder)
        {
            builder.ToTable(nameof(Origem));

            builder.HasKey(origem => origem.Id);

            builder.Property(origem => origem.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(origem => origem.Descricao).IsRequired();

            builder.HasMany(mov => mov.Transacoes)
                   .WithOne(or => or.Origem)
                   .HasForeignKey("OrigemId")
                   .HasConstraintName("FK_Origem_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_Origem")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}
