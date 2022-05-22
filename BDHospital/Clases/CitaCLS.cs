using System.ComponentModel.DataAnnotations;

namespace BDHospital.Clases
{
    public class CitaCLS
    {
        public CitaCLS()
        { }
            [Display(Name = "ID Cita")]
            public int idcita { get; set; } 
            [Display(Name = "Total a pagar")]
            public decimal totalp { get; set; }
            [Display(Name ="Id Medicamento")]
            public int IdMedicamento { get; set; }
            [Display(Name ="Nombre Medicamento")]
            public string nombreMed { get; set; }
            [Display(Name = "Id Sede")]
            public int idsede { get; set; }
            [Display(Name = "Nombre Sede")]
            public string nombreSed { get; set; }
            [Display(Name ="Id CitaMedicamento")]
            public int idcitamed { get; set; }  
            [Display(Name = "Precio medicamento")]
            public decimal preciocitmed { get; set; }
            [Display(Name ="Id Estado-Cita")]
            public int idedcit { get; set; }
            [Display(Name ="V-Nombre")]
            public string vnombre { get; set; }
            [Display(Name ="Id Historial")]
            public int idhiscit { get; set; }
            [Display(Name ="Observacion")]
            public string vobser { get; set; }
            [Display(Name ="Id Usuario")]
            public int idusuario { get; set; }
            [Display(Name = "Nombre Usuario")]
            public string nombreusuario { get; set; }
            [Display(Name ="Id Tipo-Usuario")]
            public int idtipous { get; set; }
            [Display(Name ="Descripcion")]
            public string descusuario { get; set; }

        
    }
}
