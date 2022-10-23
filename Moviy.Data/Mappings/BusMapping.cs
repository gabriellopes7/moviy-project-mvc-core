using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviy.Business.Models;

namespace Moviy.Data.Mappings
{
    public class BusMapping : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            //Id
            builder.HasKey(d => d.Id);


            //Property LicensePlate
            builder.Property(d => d.LicensePlate)
                .IsRequired()
                .HasColumnType("varchar(7)");


            builder.ToTable("Buses");


        }
    }
}
