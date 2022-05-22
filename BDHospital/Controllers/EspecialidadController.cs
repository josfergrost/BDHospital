using Microsoft.AspNetCore.Mvc;
using BDHospital.Models;
using BDHospital.Clases;


namespace BDHospital.Controllers
{
    public class EspecialidadController : Controller
    {
        public IActionResult Index(GetSetEspecialidad ogetSetEspecialidad)
        {
            ViewBag.mensaje = "Esta es una bolsa de vista";
            List<GetSetEspecialidad> lista = new List<GetSetEspecialidad>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                if((ogetSetEspecialidad.nombre == null) || (ogetSetEspecialidad.nombre==""))
                {
                    lista = (from especialidad in db.Especialidads
                             where especialidad.Bhabilitado == 1
                             select new GetSetEspecialidad
                             {
                                 idespecialidad = especialidad.Iidespecialidad,
                                 nombre = especialidad.Nombre,
                                 descripcion = especialidad.Descripcion,
                             }).ToList();
                    ViewBag.mensaje = " ";
                }
                else
                {
                    lista = (from especialidad in db.Especialidads
                             where especialidad.Bhabilitado == 1
                             && ogetSetEspecialidad.nombre.Contains(especialidad.Nombre)
                             select new GetSetEspecialidad
                             {
                                 idespecialidad = especialidad.Iidespecialidad,
                                 nombre = especialidad.Nombre,
                                 descripcion = especialidad.Descripcion,
                             }).ToList();
                    ViewBag.mensaje = ogetSetEspecialidad.nombre;
                }
                
            }
            return View(lista);
        }
        public IActionResult Agregar()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Agregar(GetSetEspecialidad oEspecialidadCLS)
        {
            try
            {
                //Conexion a nuestra Base de Datos
                using(BDHospitalContext db=new BDHospitalContext())
                {
                    if (!ModelState.IsValid)
                    {
                        return View(oEspecialidadCLS);
                    }
                    else
                    {
                        Especialidad obj=new Especialidad();
                        obj.Nombre = oEspecialidadCLS.nombre;
                        obj.Descripcion = oEspecialidadCLS.descripcion;
                        obj.Bhabilitado = 1;
                        db.Especialidads.Add(obj);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }catch (Exception ex)
            {

            }
            return View();
        }
    }
}
