using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviy.Business.Models;

namespace Moviy.Data.Mappings
{
    public class DriverMapping : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            //Id
            builder.HasKey(d => d.Id);


            builder.Property(d => d.DriverLicense)
                .IsRequired()
                .HasColumnType("varchar(11)");

            //Property Name
            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            //PropertyDocument
            builder.Property(d => d.Document)
                .IsRequired()
                .HasColumnType("varchar(8)");

            //PropertyBirthDate
            builder.Property(d => d.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.ToTable("Drivers");


        }
    }

}
