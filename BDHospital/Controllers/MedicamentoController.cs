using Microsoft.AspNetCore.Mvc;
using BDHospital.Clases;
using BDHospital.Models;
namespace BDHospital.Controllers
{
    public class MedicamentoController : Controller
    {
        public IActionResult Index()
        {
            List<MedicamentoCLS> listamedicamentos = new List<MedicamentoCLS>();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                listamedicamentos = (from Medicamento in db.Medicamentos
                                     join FormaFarmaceutica in db.FormaFarmaceuticas
                                     on Medicamento.Iidformafarmaceutica equals FormaFarmaceutica.Iidformafarmaceutica
                                     where Medicamento.Bhabilitado == 1
                                     select new MedicamentoCLS
                                     {
                                         idmedicamento = Medicamento.Iidmedicamento,
                                         nombre = Medicamento.Nombre,
                                         nombreforma = FormaFarmaceutica.Nombre,
                                         precio = (decimal)Medicamento.Precio,
                                     }
                                     ).ToList();
            }
            return View(listamedicamentos);
        }
    }
}
