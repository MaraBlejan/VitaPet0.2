using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VitaPet0._2.Models;
using VitaPet0._2.Services;

namespace VitaPet0._2.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService) => _serviceService = serviceService;

        public async Task<IActionResult> Index() => View(await _serviceService.GetAllServicesAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var service = await _serviceService.GetServiceByIdAsync(id.Value);
            if (service == null) return NotFound();
            return View(service);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServicesName,Description,Price,CreatedAt,DeletedAt")] Service service)
        {
            if (!ModelState.IsValid) return View(service);
            await _serviceService.AddServiceAsync(service);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var service = await _serviceService.GetServiceByIdAsync(id.Value);
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServicesName,Description,Price,CreatedAt,DeletedAt")] Service service)
        {
            if (id != service.Id) return NotFound();
            if (!ModelState.IsValid) return View(service);
            await _serviceService.UpdateServiceAsync(service);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var service = await _serviceService.GetServiceByIdAsync(id.Value);
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}