using Microsoft.AspNetCore.Mvc;
using BDHospital.Models;
using BDHospital.Clases;


namespace BDHospital.Controllers
{
    public class EspecialidadController : Controller
    {
        public IActionResult Index()
        {
            List<GetSetEspecialidad> lista = new List<GetSetEspecialidad>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                lista = (from especialidad in db.Especialidads where especialidad.Bhabilitado == 1 select new GetSetEspecialidad
                {
                    idespecialidad = especialidad.Iidespecialidad,
                    nombre = especialidad.Nombre ,
                    descripcion = especialidad.Descripcion,
                }).ToList();
            }
            return View(lista);
        }
    }
}
