using System.ComponentModel.DataAnnotations;

namespace BDHospital.Clases
{
    public class PaginaCLS
    {
       [Display (Name = " Id Pagina") ]
       public int idPagina { get; set; }
        [Display (Name = "Mensaje")]
        public string mensaje { get; set; }
        [Display(Name =" Accion ")]
        public string accion { get; set; }

    }
}
