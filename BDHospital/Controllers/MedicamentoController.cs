using Microsoft.AspNetCore.Mvc;
using BDHospital.Clases;
using BDHospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace BDHospital.Controllers
{
    public class MedicamentoController : Controller
    {
        public List<SelectListItem> listarformaFarmaceutica()
        {
            List<SelectListItem> listaformafarmaceutica = new List<SelectListItem>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listaformafarmaceutica = (from FormaFarmaceutica in db.FormaFarmaceuticas
                                          where FormaFarmaceutica.Bhabilitado == 1
                                          select new SelectListItem
                                          {
                                              Text = FormaFarmaceutica.Nombre,
                                              Value = FormaFarmaceutica.Iidformafarmaceutica.ToString(),
                                          }).ToList();
            }
            listaformafarmaceutica.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            return listaformafarmaceutica;
        }
        public IActionResult Index(MedicamentoCLS oMedicamentoCLS)
        {
            List<MedicamentoCLS> listamedicamentos = new List<MedicamentoCLS>();
            ViewBag.ListaForma = listarformaFarmaceutica();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                if (oMedicamentoCLS.idformafarmaceutica == 0)
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
                                             stock = (int)Medicamento.Stock,
                                         }
                                    ).ToList();
                }
                else
                {
                    listamedicamentos = (from Medicamento in db.Medicamentos
                                         join FormaFarmaceutica in db.FormaFarmaceuticas
                                         on Medicamento.Iidformafarmaceutica equals FormaFarmaceutica.Iidformafarmaceutica
                                         where Medicamento.Bhabilitado == 1 && Medicamento.Iidformafarmaceutica == oMedicamentoCLS.idformafarmaceutica
                                         select new MedicamentoCLS
                                         {
                                             idmedicamento = Medicamento.Iidmedicamento,
                                             nombre = Medicamento.Nombre,
                                             nombreforma = FormaFarmaceutica.Nombre,
                                             precio = (decimal)Medicamento.Precio,
                                             stock = (int)Medicamento.Stock,
                                         }
                                         ).ToList();
                }   
            }
            return View(listamedicamentos);
        }
    }
}
