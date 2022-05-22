using System.ComponentModel.DataAnnotations;

namespace BDHospital.Clases
{
    public class PaginaCLS
    {
       [Display (Name = " Id Doctor") ]
       public int iddoctor { get; set; }
        [Display (Name = "idsede")]
        public int idsede { get; set; }
        [Display(Name =" idespecialidad ")]
        public int idespecialidad{ get; set; }

        [Display(Name = "sueldo")]
        public string sueldo{ get; set; }
        [Display(Name = " fecha contrato ")]
        public string fechaContrato{ get; set; }

        [Display(Name = "id persona")]
        public int idpersona { get; set; }
        [Display(Name = "bhabilitado")]
        public int bhabilitado { get; set; }


    }
}
