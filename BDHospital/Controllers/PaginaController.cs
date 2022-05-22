using Microsoft.AspNetCore.Mvc;
using BDHospital.Clases;
using BDHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace BDHospital.Controllers
{
    public class PaginaController : Controller
    {
        public IActionResult Index()
        {
           // List<PaginaCLS> listaPagina = new List<PaginaCLS>();
            /* using (BDHospitalContext db =  new BDHospitalContext())
             {
                 listaPagina = (from Pagina in db.Paginas
                               where Pagina.Bhabilitado == 1
                               select new PaginaCLS
                               {
                                   idPagina = Pagina.Iidpagina,
                                   mensaje = Pagina.Mensaje,
                                   accion = Pagina.Accion,
                               }).ToList();
             }*/
            List<Doctor> list = new List<Doctor>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                
                
                list = db.Doctors.FromSqlRaw("EXEC uspListarDoctores").ToList();
            }
                return View(list);
        }
    }
}
