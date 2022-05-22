using Microsoft.AspNetCore.Mvc;
using BDHospital.Models;
using BDHospital.Clases;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BDHospital.Controllers
{
    public class PersonaController : Controller
    {
        public void llenarSexo()
        {
         List<SelectListItem> listasexo = new List<SelectListItem>();
            using (BDHospitalContext db = new BDHospitalContext())
            {
                listasexo = (from sexo in db.Sexos
                            where sexo.Bhabilitado == 1
                            select new SelectListItem
                            {
                                Text = sexo.Nombre,
                                Value = sexo.Iidsexo.ToString()
                            }).ToList();
                listasexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaSexo = listasexo;
            }
        }
        public IActionResult Index(PersonaCLS oPersonaCLS)
        {
            List<PersonaCLS> listaP = new List<PersonaCLS>();
            llenarSexo();
            using(BDHospitalContext db = new BDHospitalContext())
            {
                if(oPersonaCLS.idsexo == 0)
                {
                    listaP = (from personas in db.Personas
                              join sexo in db.Sexos
                              on personas.Iidsexo equals sexo.Iidsexo
                              where personas.Bhabilitado == 1
                              select new PersonaCLS
                              {
                                  idpersona = personas.Iidpersona,
                                  NombreCompleto = personas.Nombre + " " + personas.Appaterno + " " + personas.Apmaterno,
                                  email = personas.Email,
                                  nsexo = sexo.Nombre
                              }).ToList();
                }else
                {
                    listaP = (from personas in db.Personas
                              join sexo in db.Sexos
                              on personas.Iidsexo equals sexo.Iidsexo
                              where personas.Bhabilitado == 1 && personas.Iidsexo == oPersonaCLS.idsexo
                              select new PersonaCLS
                              {
                                  idpersona = personas.Iidpersona,
                                  NombreCompleto = personas.Nombre + " " + personas.Appaterno + " " + personas.Apmaterno,
                                  email = personas.Email,
                                  nsexo = sexo.Nombre
                              }).ToList();
                }

                
            }
            return View(listaP);
        }
    }
}
