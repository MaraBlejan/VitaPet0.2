using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VitaPet0._2.Models;
using VitaPet0._2.Services;

namespace VitaPet0._2.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService) => _ownerService = ownerService;

        public async Task<IActionResult> Index() => View(await _ownerService.GetAllOwnersAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var owner = await _ownerService.GetOwnerByIdAsync(id.Value);
            if (owner == null) return NotFound();
            return View(owner);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Phone,Email,Address,CreatedAt,DeletedAt")] Owner owner)
        {
            if (!ModelState.IsValid) return View(owner);
            await _ownerService.AddOwnerAsync(owner);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var owner = await _ownerService.GetOwnerByIdAsync(id.Value);
            if (owner == null) return NotFound();
            return View(owner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone,Email,Address,CreatedAt,DeletedAt")] Owner owner)
        {
            if (id != owner.Id) return NotFound();
            if (!ModelState.IsValid) return View(owner);
            await _ownerService.UpdateOwnerAsync(owner);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var owner = await _ownerService.GetOwnerByIdAsync(id.Value);
            if (owner == null) return NotFound();
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ownerService.DeleteOwnerAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}