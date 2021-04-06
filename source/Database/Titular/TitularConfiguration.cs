using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class TitularConfiguration : IEntityTypeConfiguration<Titular>
    {
        public void Configure(EntityTypeBuilder<Titular> builder)
        {
            builder.ToTable(nameof(Titular));

            builder.HasKey(titular => titular.Id);

            builder.Property(titular => titular.Id).ValueGeneratedOnAdd().IsRequired();

            builder.OwnsOne(titular => titular.Nome, titularNome =>
            {
                titularNome.Property(titular => titular.PrimeiroNome).HasColumnName(nameof(Nome.PrimeiroNome)).HasMaxLength(100).IsRequired();

                titularNome.Property(titular => titular.Sobrenome).HasColumnName(nameof(Nome.Sobrenome)).HasMaxLength(200).IsRequired();
            });

            builder.OwnsOne(titular => titular.Email, titularEmail =>
            {
                titularEmail.Property(email => email.Value).HasColumnName(nameof(Email)).HasMaxLength(300).IsRequired();

                titularEmail.HasIndex(email => email.Value).IsUnique();
            });

            builder.OwnsOne(titular => titular.Telefone, titularTel =>
            {
                titularTel.Property(telefone => telefone.Numero).HasColumnName(nameof(Telefone)).IsRequired();

                titularTel.HasIndex(telefone => telefone.Numero).IsUnique();
            });

            builder.OwnsOne(titular => titular.CPF, titularCPF =>
            {
                titularCPF.Property(cpf => cpf.Numero).HasColumnName(nameof(CPF)).IsRequired();

                titularCPF.HasIndex(cpf => cpf.Numero).IsUnique();
            });

            builder.HasOne(cartao => cartao.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId")
                   .HasConstraintName("FK_Usuario_Titular")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasMany(mov => mov.Transacoes)
                   .WithOne(op => op.Titular)
                   .HasForeignKey("CartaoId")
                   .HasConstraintName("FK_Titular_Transacao")
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}
