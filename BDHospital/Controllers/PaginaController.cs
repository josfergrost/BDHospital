using Microsoft.AspNetCore.Mvc;
using BDHospital.Clases;
using BDHospital.Models;
namespace BDHospital.Controllers
{
    public class PaginaController : Controller
    {
        public IActionResult Index()
        {
            List<PaginaCLS> listaPagina = new List<PaginaCLS>();
            using (BDHospitalContext db =  new BDHospitalContext())
            {
                listaPagina = (from Pagina in db.Paginas
                              where Pagina.Bhabilitado == 1
                              select new PaginaCLS
                              {
                                  idPagina = Pagina.Iidpagina,
                                  mensaje = Pagina.Mensaje,
                                  accion = Pagina.Accion,
                              }).ToList();
            }
            return View(listaPagina);
        }
    }
}
