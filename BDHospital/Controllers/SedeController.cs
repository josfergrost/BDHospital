using Microsoft.AspNetCore.Mvc;
using BDHospital.Clases;
using BDHospital.Models;
namespace BDHospital.Controllers
{
    public class SedeController : Controller
    {
       
        public IActionResult Index(SedeCLS oSedeCLS)
        {
            List<SedeCLS> listasede = new List<SedeCLS>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                if(oSedeCLS.nombre == null || oSedeCLS.nombre == "")
                {
                    listasede = (from sede in db.Sedes
                                 where sede.Bhabilitado == 1
                                 select new SedeCLS
                                 {
                                     idSede = sede.Iidsede,
                                     nombre = sede.Nombre,
                                     direccion = sede.Direccion,
                                 }).ToList();
                    ViewBag.NombreSede = " ";
                }
                else
                {
                    listasede = (from sede in db.Sedes
                                 where sede.Bhabilitado == 1 && sede.Nombre.Contains(oSedeCLS.nombre)
                                 select new SedeCLS
                                 {
                                     idSede = sede.Iidsede,
                                     nombre = sede.Nombre,
                                     direccion = sede.Direccion,
                                 }).ToList();
                    ViewBag.NombreSede = oSedeCLS.nombre;
                }
                
            }
                return View(listasede);
        }
    }
}
