namespace Moviy.Business.Models
{
    public class Driver : Entity
    {
        public string DriverLicense { get; set; }

        public string Name { get; set; }
        public string Document { get; set; }

        public DateTime BirthDate { get; set; }


        public string Image { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ActivatedAt { get; set; }
        public DateTime? DeactivatedAt { get; set; }

        //EF relation with travels

        public IEnumerable<Travel> Travels { get; set; }
    }
}
