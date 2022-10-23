namespace Moviy.Business.Models
{
    public class Bus : Entity
    {
        public int BusNumber { get; set; }
        public string LicensePlate { get; set; }
        public BusColor BusColor { get; set; }
        public BusSize BusSize { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ActivatedAt { get; set; }
        public DateTime? DeactivatedAt { get; set; }

        //Relation with Travel
        public IEnumerable<Travel> Travels { get; set; }

    }
}
