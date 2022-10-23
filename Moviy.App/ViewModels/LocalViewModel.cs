using System.ComponentModel.DataAnnotations;

namespace Moviy.App.ViewModels
{
    public class LocalViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Country { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string State { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string District { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Code { get; set; }


        //EF relation with Routes
        public IEnumerable<LineRouteViewModel> StartPoints { get; set; }

        public IEnumerable<LineRouteViewModel> EndPoints { get; set; }
    }
}
