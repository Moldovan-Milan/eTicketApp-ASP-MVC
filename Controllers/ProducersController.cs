using eTicketApp.Data;
using eTicketApp.Data.Services;
using eTicketApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicketApp.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var producers = await _service.GetAllAsync();
            return View(producers);
        }

        // GET: /Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post: /Producers/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction("Index");
        }

        // Get: /Details/1
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if (producer == null)
                return View("NotFound");
            return View(producer);
        }

        // Get: /Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if (producer == null)
                return View("NotFound");
            return View(producer);
        }

        // Post: /Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
                return View(producer);
            await _service.UpdateAsync(id, producer);
            return RedirectToAction("Index");
        }

        // Get: Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if (producer == null)
                return View("NotFound");
            return View(producer);
        }

        // Post: Delete/1
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if (actor == null)
                return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
