using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moviy.App.ViewModels
{
    public class DriverViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} tem que ter {1} caracteres")]
        [DisplayName("Nº Habilitação")]
        public string DriverLicense { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} tem que ter {1} caracteres")]
        [DisplayName("Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayName("Data Nascimento")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Foto")]
        public string Image { get; set; }

        [DisplayName("Foto")]
        public IFormFile ImageUpload { get; set; }

        [DisplayName("Ativo ?")]
        public bool IsActive { get; set; }

        public DateTime? ActivatedAt { get; set; }
        public DateTime? DeactivatedAt { get; set; }

        //EF relation with travels

        public IEnumerable<TravelViewModel> Travels { get; set; }

    }
}
