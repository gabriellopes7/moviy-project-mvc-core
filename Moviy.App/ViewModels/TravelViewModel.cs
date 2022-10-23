using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moviy.App.ViewModels
{
    public class TravelViewModel
    {
        public TravelViewModel()
        {
            BusList = new List<SelectListItem>();
            DriverList = new List<SelectListItem>();
            LineRouteList = new List<SelectListItem>();
        }


        [Key]
        public Guid Id { get; set; }


        [DisplayName("Motorista")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid DriverId { get; set; }

        public DriverViewModel Driver { get; set; }

        [DisplayName("Veículo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid BusId { get; set; }

        public BusViewModel Bus { get; set; }

        [DisplayName("Linha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid LineRouteId { get; set; }

        public LineRouteViewModel LineRoute { get; set; }



        [DisplayName("Iniciada em")]
        public DateTime StartedAt { get; set; }

        [DisplayName("Finalizada em")]
        public DateTime? FinishedAt { get; set; }

        public DateTime? DeletedAt { get; set; }


        public List<SelectListItem> BusList { get; set; }
        public List<SelectListItem> DriverList { get; set; }
        public List<SelectListItem> LineRouteList { get; set; }
    }
}
