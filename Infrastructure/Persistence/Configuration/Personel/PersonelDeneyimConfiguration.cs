using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.Personel
{
    public class PersonelDeneyimConfiguration : BaseEntityConfiguration<PersonelDeneyim>
    {
        public override void Configure(EntityTypeBuilder<PersonelDeneyim> builder)
        {
            base.Configure(builder);
            builder.HasOne(c => c.Personel)
                .WithMany(d => d.PersonelDeneyims)
                .HasForeignKey(c => c.PersonelId);
        }
    }
}
