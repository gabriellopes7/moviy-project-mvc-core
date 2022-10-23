namespace Moviy.Business.Models
{
    public class LineRoute : Entity
    {
        public Guid StartPointId { get; set; }

        public decimal LinePrice { get; set; }
        public string Line { get; set; }

        public Local StartPoint { get; set; }

        public Guid EndPointId { get; set; }
        public Local EndPoint { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ActivatedAt { get; set; }
        public DateTime? DeactivatedAt { get; set; }


        //EF Relation
        public IEnumerable<Travel> Travels { get; set; }
    }
}
