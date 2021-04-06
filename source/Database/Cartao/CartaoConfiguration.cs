using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class CartaoConfiguration : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable(nameof(Cartao));

            builder.HasKey(cartao => cartao.Id);

            builder.Property(cartao => cartao.Id).ValueGeneratedOnAdd().IsRequired();

            builder.OwnsOne(cartao => cartao.Numero, cartaoNumero =>
            {
                cartaoNumero.Property(cartao => cartao.Numero).HasColumnName(nameof(NumeroCartao)).IsRequired();

                cartaoNumero.HasIndex(cartao => cartao.Numero).IsUnique();
            });

            builder.OwnsOne(user => user.Nome, userName =>
            {
                userName.Property(name => name.PrimeiroNome).HasColumnName(nameof(Nome.PrimeiroNome)).HasMaxLength(100).IsRequired();

                userName.Property(name => name.Sobrenome).HasColumnName(nameof(Nome.Sobrenome)).HasMaxLength(200).IsRequired();
            });

            builder.HasOne(cartao => cartao.Tipo)
                   .WithMany(tipo => tipo.Cartoes)
                   .HasForeignKey("TipoCartaoId")
                   .HasConstraintName("FK_TipoCartao_Cartao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasMany(mov => mov.Transacoes)
                   .WithOne(op => op.Cartao)
                   .HasForeignKey("CartaoId")
                   .HasConstraintName("FK_Cartao_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_Cartao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

        }
    }
}
