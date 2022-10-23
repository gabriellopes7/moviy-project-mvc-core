using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moviy.Business.Models;

namespace Moviy.Data.Mappings
{
    public class LineRouteMapping : IEntityTypeConfiguration<LineRoute>
    {
        public void Configure(EntityTypeBuilder<LineRoute> builder)
        {
            //Id
            builder.HasKey(d => d.Id);


            builder.HasOne(r => r.StartPoint)
                .WithMany(l => l.StartPoints)
                .HasForeignKey(r => r.StartPointId);

            builder.HasOne(r => r.EndPoint)
                .WithMany(l => l.EndPoints)
                .HasForeignKey(r => r.EndPointId);

            builder.ToTable("LineRoutes");


        }
    }
}
