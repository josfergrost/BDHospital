using Microsoft.AspNetCore.Mvc;
using BDHospital.Models;
using BDHospital.Clases;
namespace BDHospital.Controllers
{
    public class CitaController : Controller
    {
        public IActionResult Index()
        {
            List<CitaCLS>listacita = new List<CitaCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listacita = (from cita in db.Cita
                             join sede in db.Sedes on cita.Iidsede equals sede.Iidsede
                             join citamedicamento in db.CitaMedicamentos on cita.Iidcita equals citamedicamento.Iidcita
                             join medicamento in db.Medicamentos on citamedicamento.Iidmedicamento equals medicamento.Iidmedicamento
                             join estadocita in db.EstadoCita on cita.Iidestadocita equals estadocita.Iidestado
                             join usuario in db.Usuarios on cita.Iidusuario equals usuario.Iidusuario
                             join tipousuario in db.TipoUsuarios on usuario.Iidtipousuario equals tipousuario.Iidtipousuario
                             join historialcita in db.HistorialCita on cita.Iidcita equals historialcita.Iidcita
                             where cita.Bhabilitado == 1
                             select new CitaCLS
                             {
                                 idcita = cita.Iidcita,
                                 totalp = (decimal)cita.Totalpagar,
                                 IdMedicamento = medicamento.Iidmedicamento,
                                 nombreMed = medicamento.Nombre,
                                 idsede = sede.Iidsede,
                                 nombreSed = sede.Nombre,
                                 idcitamed = citamedicamento.Iidcitamedicamento,
                                 preciocitmed = (decimal)citamedicamento.Precio,
                                 idedcit = estadocita.Iidestado,
                                 vnombre = estadocita.Vnombre,
                                 idhiscit = historialcita.Iidhistorialcita,
                                 vobser = historialcita.Vobservacion,
                                 idusuario = usuario.Iidusuario,
                                 nombreusuario = usuario.Nombreusuario,



                             }


                             ).ToList();
            }
                return View();
        }
    }
}
