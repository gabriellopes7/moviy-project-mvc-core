using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moviy.App.ViewModels
{
    public class BusViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Número do veículo")]
        public int BusNumber { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Placa do veículo")]
        [StringLength(7, ErrorMessage = ("O campo {0} precisa ter {1} caracteres"))]
        public string LicensePlate { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Cor")]
        public int BusColor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Tamanho do veículo")]
        public int BusSize { get; set; }

        [DisplayName("Ativo ?")]
        public bool IsActive { get; set; }

        public DateTime? ActivatedAt { get; set; }
        public DateTime? DeactivatedAt { get; set; }

        //Relation with Travel
        public IEnumerable<TravelViewModel> Travels { get; set; }


    }
}
