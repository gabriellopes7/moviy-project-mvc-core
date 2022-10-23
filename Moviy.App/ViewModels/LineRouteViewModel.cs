using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moviy.App.ViewModels
{
    public class LineRouteViewModel
    {
        public LineRouteViewModel()
        {
            LocalsList = new List<SelectListItem>();
        }


        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Número da Linha")]
        public string Line { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Ponto Inicial")]
        public Guid StartPointId { get; set; }

        public LocalViewModel StartPoint { get; set; }

        public LocalViewModel EndPoint { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Ponto Final")]
        public Guid EndPointId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        [DisplayName("Preço")]
        public decimal LinePrice { get; set; }

        [DisplayName("Ativo ?")]
        public bool IsActive { get; set; }



        public DateTime? ActivatedAt { get; set; }
        public DateTime? DeactivatedAt { get; set; }


        //EF Relation
        public IEnumerable<TravelViewModel> Travels { get; set; }

        public IEnumerable<LocalViewModel> Locals { get; set; }

        public List<SelectListItem> LocalsList { get; set; }


    }
}
