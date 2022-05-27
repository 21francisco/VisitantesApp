using Microsoft.AspNetCore.Mvc;
using VisitantesApp.Interfaces;
using VisitantesApp.Models;
using VisitantesApp.Repository;
using VisitantesApp.ViewModels;

namespace VisitantesApp.Controllers
{
    public class VisitanteController : Controller
    {
        private readonly IVisitante _visitanteRepository;

        public VisitanteController(IVisitante visitanteRepository)
        {
           _visitanteRepository = visitanteRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearVisitante(AgregarVisitanteViewModel VisitanteVM) 
        {
            if (VisitanteVM is null)
            {
                return BadRequest();
            }

            

            AgregarVisitanteViewModel model = await _visitanteRepository.AgregarVisitante(VisitanteVM);

            if (model is null)
            {
                return BadRequest();
            }


            return View(model);
        
        }

        private void Fetchdata()
        { 
        
        
        
        }
    }
}
