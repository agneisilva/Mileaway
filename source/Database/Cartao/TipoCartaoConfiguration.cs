using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class TipoCartaoConfiguration : IEntityTypeConfiguration<TipoCartao>
    {
        public void Configure(EntityTypeBuilder<TipoCartao> builder)
        {
            builder.ToTable(nameof(TipoCartao));

            builder.HasKey(cartao => cartao.Id);

            builder.Property(cartao => cartao.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(auth => auth.Descricao).HasMaxLength(100).IsRequired();

            builder.HasMany(tipo => tipo.Cartoes)
                   .WithOne(cartao => cartao.Tipo)
                   .HasForeignKey("TipoCartaoId")
                   .HasConstraintName("FK_TipoCartao_Cartao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_TipoCartao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}
