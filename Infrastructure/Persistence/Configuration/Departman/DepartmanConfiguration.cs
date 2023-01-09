using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.Departman
{
    public class DepartmanConfiguration : BaseEntityConfiguration<Domain.Entities.Departman>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Departman> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.Sube)
                .WithMany(d => d.Departman)
                .HasForeignKey(c => c.SubeId);
        }
    }
}
