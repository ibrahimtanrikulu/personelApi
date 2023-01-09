using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.Departman
{
    public class DepartmanRolConfiguration : BaseEntityConfiguration<DepartmanRol>
    {
        public override void Configure(EntityTypeBuilder<DepartmanRol> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.Departman)
                .WithMany(d => d.DepartmanRols)
                .HasForeignKey(c => c.DepartmanId);
        }
    }
}
