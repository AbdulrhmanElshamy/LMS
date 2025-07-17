using LMS.Domian.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence.Configurations
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();


            builder.OwnsOne(p => p.PhoneNumber, phone =>
            {
                phone.Property(pn => pn.Value).HasColumnName("ParentPhone");
            });

            builder.OwnsOne(p => p.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("ParentEmail");
            });
        }
    }   


}
