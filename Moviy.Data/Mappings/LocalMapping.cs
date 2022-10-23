using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviy.Business.Models;

namespace Moviy.Data.Mappings
{
    public class LocalMapping : IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder)
        {
            //Id
            builder.HasKey(d => d.Id);


            builder.Property(d => d.Code)
                .IsRequired()
                .HasColumnType("varchar(8)");

            //Property Number
            builder.Property(d => d.Number)
                .IsRequired()
                .HasColumnType("varchar(50)");

            //Property Street
            builder.Property(d => d.Street)
                .IsRequired()
                .HasColumnType("varchar(200)");

            //Property District
            builder.Property(d => d.District)
                .IsRequired()
                .HasColumnType("varchar(200)");

            //Property City
            builder.Property(d => d.City)
                .IsRequired()
                .HasColumnType("varchar(100)");

            //Property State
            builder.Property(d => d.State)
                .IsRequired()
                .HasColumnType("varchar(50)");

            //Property Country
            builder.Property(d => d.Country)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Locals");


        }
    }
}
