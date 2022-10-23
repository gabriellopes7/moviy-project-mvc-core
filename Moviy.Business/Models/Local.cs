namespace Moviy.Business.Models
{
    public class Local : Entity
    {
        public string Country { get; set; }

        public string City { get; set; }
        public string District { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Code { get; set; }

        public string State { get; set; }


        //EF relation with Routes
        public IEnumerable<LineRoute> StartPoints { get; set; }

        public IEnumerable<LineRoute> EndPoints { get; set; }

    }
}