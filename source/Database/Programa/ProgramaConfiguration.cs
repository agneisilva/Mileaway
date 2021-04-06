using Architecture.Domain;
using Architecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Architecture.Database
{
    public sealed class ProgramaConfiguration : IEntityTypeConfiguration<Programa>
    {
        public void Configure(EntityTypeBuilder<Programa> builder)
        {
            builder.ToTable(nameof(Programa));

            builder.HasKey(origem => origem.Id);

            builder.Property(origem => origem.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(origem => origem.Descricao).IsRequired();

            builder.HasMany(mov => mov.Transacoes)
                   .WithOne(or => or.Programa)
                   .HasForeignKey("ProgramaId")
                   .HasConstraintName("FK_Programa_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_Programa")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();


        }
    }
}
