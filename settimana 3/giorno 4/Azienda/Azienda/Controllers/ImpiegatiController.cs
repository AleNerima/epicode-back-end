using Microsoft.AspNetCore.Mvc;
using Azienda.Models;
using Azienda.Services;
using System.Collections.Generic;

namespace Azienda.Controllers
{
    public class ImpiegatoController : Controller
    {
        private readonly IImpiegatoService _impiegatoService;

        public ImpiegatoController(IImpiegatoService impiegatoService)
        {
            _impiegatoService = impiegatoService;
        }

        // GET: Impiegato
        public IActionResult Index()
        {
            IEnumerable<Impiegato> impiegati = _impiegatoService.GetImpiegati();
            return View(impiegati);
        }

        // GET: Impiegato/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Impiegato impiegato = _impiegatoService.GetImpiegatoById(id.Value);

            if (impiegato == null)
            {
                return NotFound();
            }

            return View(impiegato);
        }

        // GET: Impiegato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Impiegato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Impiegato impiegato)
        {
            if (ModelState.IsValid)
            {
                _impiegatoService.InsertImpiegato(impiegato);
                return RedirectToAction(nameof(Index));
            }
            return View(impiegato);
        }

        // GET: Impiegato/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Impiegato impiegato = _impiegatoService.GetImpiegatoById(id.Value);

            if (impiegato == null)
            {
                return NotFound();
            }

            return View(impiegato);
        }

        // POST: Impiegato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Impiegato impiegato)
        {
            if (id != impiegato.IDImpiegato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _impiegatoService.UpdateImpiegato(impiegato);
                return RedirectToAction(nameof(Index));
            }
            return View(impiegato);
        }

        // GET: Impiegato/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Impiegato impiegato = _impiegatoService.GetImpiegatoById(id.Value);

            if (impiegato == null)
            {
                return NotFound();
            }

            return View(impiegato);
        }

        // POST: Impiegato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _impiegatoService.DeleteImpiegato(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
