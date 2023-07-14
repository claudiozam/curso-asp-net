using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSistemaDeReclamos.Models;
using WebApplicationSistemaDeReclamos.Models.ViewModels;
using WebApplicationSistemaDeReclamos.Services;

namespace WebApplicationSistemaDeReclamos.Controllers
{
    public class ReclamosController : Controller
    {
        // GET: ReclamosController

        public ActionResult Buscar(string textoBucar)
        {
            ReclamosService reclamosService = new ReclamosService();
            List<Reclamo> reclamos = reclamosService.RecuperarListadoDeReclamos(textoBucar);

            List<ReclamoViewModel> reclamosViewModel = new List<ReclamoViewModel>();
            foreach (Reclamo r in reclamos)
            {
                reclamosViewModel.Add(new ReclamoViewModel()
                {
                    Id = r.Id,
                    Titulo = r.Titulo,
                    Descripcion = r.Descripcion,
                    Estado = r.Estado,
                    FechaAlta = r.FechaAlta
                });
            }
            ViewBag.textoBucar = textoBucar;
            return View("Index", reclamosViewModel);
        }

        
        public ActionResult Index()
        {
            ReclamosService reclamosService = new ReclamosService();
            List<Reclamo> reclamos = reclamosService.RecuperarListadoDeReclamos();

            List<ReclamoViewModel> reclamosViewModel = new List<ReclamoViewModel>();
            foreach(Reclamo r in reclamos)
            {
                reclamosViewModel.Add(new ReclamoViewModel() { 
                    Id = r.Id,
                    Titulo = r.Titulo,
                    Descripcion = r.Descripcion,
                    Estado = r.Estado,
                    FechaAlta = r.FechaAlta
                });
            }
       
            return View(reclamosViewModel);
        }

        // GET: ReclamosController/Details/5
        public ActionResult Details(int id)
        {
            ReclamosService reclamosService = new ReclamosService();
            Reclamo reclamo = reclamosService.RecuperarReclamo(id);
            ReclamoViewModel reclamoViewModel = new ReclamoViewModel();
            reclamoViewModel.Id = id;
            reclamoViewModel.Titulo = reclamo.Titulo;
            reclamoViewModel.Descripcion = reclamo.Descripcion;
            reclamoViewModel.Estado = reclamo.Estado;
            reclamoViewModel.FechaAlta = reclamo.FechaAlta;

            return View(reclamoViewModel);
        }

        // GET: ReclamosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclamosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReclamoViewModel reclamoViewModel)
        {
            if(ModelState.IsValid)
            {
                ReclamosService reclamosService = new ReclamosService();
                Reclamo reclamo = new Reclamo();
                reclamo.Titulo = reclamoViewModel.Titulo;
                reclamo.Descripcion = reclamoViewModel.Descripcion;
                reclamo.Estado = reclamoViewModel.Estado;
                reclamo.FechaAlta = DateTime.Now;

                reclamosService.AltaDeReclamo(reclamo);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //HAY ALGUN ERROR DE VALIDACION... VUELVO A MOSTRAR EL FORMULARIO
                return View();
            }
 
        }

        // GET: ReclamosController/Edit/5
        public ActionResult Edit(int id)
        {
            ReclamosService reclamosService = new ReclamosService();
            Reclamo reclamo = reclamosService.RecuperarReclamo(id);
            ReclamoViewModel reclamoViewModel = new ReclamoViewModel();
            reclamoViewModel.Id = id;
            reclamoViewModel.Titulo = reclamo.Titulo;
            reclamoViewModel.Descripcion = reclamo.Descripcion;
            reclamoViewModel.Estado = reclamo.Estado;
            reclamoViewModel.FechaAlta = reclamo.FechaAlta;
            return View(reclamoViewModel);
        }

        // POST: ReclamosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReclamoViewModel reclamoViewModel)
        {
            if (ModelState.IsValid)
            {

                ReclamosService reclamosService = new ReclamosService();
                Reclamo reclamo = reclamosService.RecuperarReclamo(id);
                reclamo.Id = id;
                reclamo.Titulo = reclamoViewModel.Titulo;
                reclamo.Descripcion = reclamoViewModel.Descripcion;
                reclamo.Estado = reclamoViewModel.Estado;
                reclamosService.ActualizarReclamo(reclamo);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                //HAY ALGUN ERROR DE VALIDACION... VUELVO A MOSTRAR EL FORMULARIO
                return View();
            }
        }

        // GET: ReclamosController/Delete/5
        public ActionResult Delete(int id)
        {
            //TODO borrar de la base de datos el reclamo

            ReclamosService reclamosService = new ReclamosService();
            reclamosService.BorrarReclamo(id);

            return RedirectToAction(nameof(Index));
        }
        
    }
}
