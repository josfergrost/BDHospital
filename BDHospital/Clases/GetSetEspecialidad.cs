using System.ComponentModel.DataAnnotations;

namespace BDHospital.Clases
{
    public class GetSetEspecialidad
    {
        public GetSetEspecialidad() { }
        [Display (Name="ID especialidad")]
        public int idespecialidad { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = " EL nombre de la especialidad es requerido")]
        public string nombre { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = " La descripcion de la especialidad es requerido")]
        public string descripcion { get; set; }


    }
}
