using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.Personel
{
    public class PersonelSirketConfiguration : BaseEntityConfiguration<PersonelSirket>
    {
        public override void Configure(EntityTypeBuilder<PersonelSirket> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.Sube)
                .WithMany(d => d.PersonelSirkets)
                .HasForeignKey(c => c.SubeId);
        }
    }
}
