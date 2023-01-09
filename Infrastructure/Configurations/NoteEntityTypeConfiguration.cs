using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class NoteEntityTypeConfiguration: IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(100);

        builder
            .Property<DateTime>("_updatedAt")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .IsRequired();
    }
}