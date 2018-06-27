using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notas02.Application.Entities;

namespace Notas02.Application.EF.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(typeof(Cliente).Name);

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(255)
                .IsRequired();

            builder.Ignore(c => c.ValidationResult);
        }
    }
}