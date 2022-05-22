using System.ComponentModel.DataAnnotations;

namespace BDHospital.Clases
{
    public class PersonaCLS
    {
        public PersonaCLS () { }
        [Display(Name = "ID Persona")]
        public int idpersona { get; set; }
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Correo")]
        public string email { get; set; }
        [Display(Name = "Sexo")]
        public string nsexo { get; set; }
        
        public int idsexo { get; set; }
        
    }

    }

    


