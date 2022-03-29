using System.ComponentModel.DataAnnotations;
namespace BDHospital.Clases
{
    public class SedeCLS
    {
        [Display (Name = "ID Sede")]
        public int idSede { get; set; }
        [Display(Name = "Nombre Sede")]
        public string nombre { get; set; }
        [Display(Name = "Direccion Sede")]
        public string direccion { get; set; }


    }
}
