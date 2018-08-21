using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notas02.Application.Entities;

namespace Notas02.Application.EF.Mappings
{
    public class NotaMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable(typeof(Nota).Name);

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.Referencia)
                .HasColumnName("Referencia")
                .IsRequired();

            builder.Property(c => c.ValorUnitario)
                .HasColumnName("ValorUnitario")
                .IsRequired();

            builder.Property(c => c.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();
        }
    }
}
