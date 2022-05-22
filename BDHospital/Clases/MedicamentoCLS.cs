
using System.ComponentModel.DataAnnotations;
namespace BDHospital.Clases
{
    public class MedicamentoCLS
    {
        public MedicamentoCLS() { }
        [Display(Name = "ID Medicamento")]
        public int idmedicamento { get; set; }
        [Display(Name = "Nombre Medicamento")]
        public string nombre { get; set; }
        [Display(Name = "Forma Farmaceutica")]
        public string nombreforma { get; set; }
        [Display(Name = "Precio")]
        public decimal precio { get; set; }
        [Display(Name = "Stock")]
        public int stock { get; set; }
        public int idformafarmaceutica { get; set; }

    }
}
