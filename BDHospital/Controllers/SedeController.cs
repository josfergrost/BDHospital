using Microsoft.AspNetCore.Mvc;
using BDHospital.Clases;
using BDHospital.Models;
namespace BDHospital.Controllers
{
    public class SedeController : Controller
    {
       
        public IActionResult Index()
        {
            List<SedeCLS> listasede = new List<SedeCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listasede = (from sede in db.Sedes
                             where sede.Bhabilitado == 1
                             select new SedeCLS {
                                 idSede = sede.Iidsede,
                                 nombre = sede.Nombre,
                                 direccion = sede.Direccion,
                             }).ToList();
            }
                return View(listasede);
        }
    }
}
