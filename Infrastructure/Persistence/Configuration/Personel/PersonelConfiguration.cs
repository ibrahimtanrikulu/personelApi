using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration.Personel
{
    public class PersonelConfiguration : BaseEntityConfiguration<Domain.Entities.Personel>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Personel> builder)
        {
            base.Configure(builder);
        }
    }
}
