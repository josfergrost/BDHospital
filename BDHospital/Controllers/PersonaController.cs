using Microsoft.AspNetCore.Mvc;
using BDHospital.Models;
using BDHospital.Clases;
namespace BDHospital.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            List<PersonaCLS> listaP = new List<PersonaCLS>();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                listaP = (from personas in db.Personas
                         join sexo in db.Sexos
                         on personas.Iidsexo equals sexo.Iidsexo
                         where personas.Bhabilitado == 1
                         select new PersonaCLS
                         {
                             idpersona = personas.Iidpersona,
                             NombreCompleto = personas.Nombre+" "+personas.Appaterno+" "+personas.Apmaterno,
                             email = personas.Email,
                             nsexo = sexo.Nombre
                         }).ToList();
            }
            return View(listaP);
        }
    }
}
