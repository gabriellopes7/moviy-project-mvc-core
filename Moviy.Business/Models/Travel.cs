namespace Moviy.Business.Models
{
    public class Travel : Entity
    {

        //EF relation with driver
        public Guid DriverId { get; set; }

        public Driver Driver { get; set; }


        //EF relation with bus
        public Guid BusId { get; set; }
        public Bus Bus { get; set; }

        //EF relation with Routes
        public Guid LineRouteId { get; set; }

        public LineRoute LineRoute { get; set; }


        public DateTime StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
