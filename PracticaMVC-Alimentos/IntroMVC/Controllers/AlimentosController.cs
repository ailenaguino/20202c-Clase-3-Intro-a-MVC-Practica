using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroMVC.Controllers
{
    public class AlimentosController : Controller
    {
        //Seguis acá? Escuchá Faun entonces

        AlimentosServicio AlS = new AlimentosServicio();

        public ActionResult Todos()
        {
            List<Alimento> alimentos = AlS.ListarAlimentos();

            return View(alimentos);
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection form)
        {
            Alimento a = new Alimento();
            a.Nombre = form["Nombre"];
            a.Peso = Int32.Parse(form["Peso"]);

            AlS.CrearAlimento(a);

            return RedirectToAction("Todos");
        }

        public ActionResult Editar(int id)
        {
            Alimento a = AlS.BuscarAlimentoPorId(id);

            return View(a);
        }

        [HttpPost]
        public ActionResult Editar(FormCollection form)
        {
            Alimento a = new Alimento();
            a.Nombre = form["Nombre"];
            a.Peso = Int32.Parse(form["Peso"]);
            a.Id = Int32.Parse(form["Id"]);

            AlS.Editar(a);

            return RedirectToAction("Todos");
        }

        public ActionResult Borrar(int id)
        {
            AlS.Eliminar(id);

            return RedirectToAction("Todos");
        }
    }
}