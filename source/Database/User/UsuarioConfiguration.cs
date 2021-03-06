using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(user => user.Status).IsRequired();

            builder.OwnsOne(user => user.Name, userName =>
            {
                userName.Property(name => name.PrimeiroNome).HasColumnName(nameof(Nome.PrimeiroNome)).HasMaxLength(100).IsRequired();

                userName.Property(name => name.Sobrenome).HasColumnName(nameof(Nome.Sobrenome)).HasMaxLength(200).IsRequired();
            });

            builder.OwnsOne(user => user.Email, userEmail =>
            {
                userEmail.Property(email => email.Value).HasColumnName(nameof(Email)).HasMaxLength(300).IsRequired();

                userEmail.HasIndex(email => email.Value).IsUnique();
            });

            builder.HasOne(user => user.Auth).WithOne().HasForeignKey<Usuario>("AuthId").IsRequired();

            builder.HasIndex("AuthId").IsUnique();
        }
    }
}
