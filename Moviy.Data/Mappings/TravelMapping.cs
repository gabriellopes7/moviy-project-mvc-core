using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviy.Business.Models;

namespace Moviy.Data.Mappings
{
    public class TravelMapping : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            //Id
            builder.HasKey(t => t.Id);



            //Relations with driver
            builder.HasOne(d => d.Driver)
                .WithMany(t => t.Travels)
                .HasForeignKey(t => t.DriverId);

            //Relation with bus
            builder.HasOne(t => t.Bus)
                .WithMany(b => b.Travels)
                .HasForeignKey(t => t.BusId);

            //Relation with Routes
            builder.HasOne(t => t.LineRoute)
                .WithMany(r => r.Travels)
                .HasForeignKey(t => t.LineRouteId);



            builder.ToTable("Travels");


        }
    }
}
