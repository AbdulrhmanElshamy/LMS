using LMS.Domian.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName).IsRequired();

            builder.Property(s => s.LastName).IsRequired();


            builder.OwnsOne(s => s.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email");
            });

            builder.OwnsOne(s => s.Mobile, mobile =>
            {
                mobile.Property(m => m.Value).HasColumnName("Mobile");
            });

            builder.Property(s => s.DateOfBirth).IsRequired();

            builder
                .HasOne(s => s.Parent)
                .WithOne()
                .HasForeignKey<Parent>(p => p.StudentId);

            builder
                .HasOne(s => s.Guardian)
                .WithOne()
                .HasForeignKey<Guardian>(g => g.StudentId);
        }
    } 
}
