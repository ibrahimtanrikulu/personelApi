using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.Personel
{
    public class PersonelIzinConfiguration : BaseEntityConfiguration<PersonelIzin>
    {
        public override void Configure(EntityTypeBuilder<PersonelIzin> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.Personel)
                .WithMany(d => d.PersonelIzins)
                .HasForeignKey(c => c.PersonelId);
        }
    }
}
