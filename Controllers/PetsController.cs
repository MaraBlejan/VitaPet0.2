using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VitaPet0._2.Models;
using VitaPet0._2.Services;

namespace VitaPet0._2.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;

        public PetsController(IPetService petService, IOwnerService ownerService)
        {
            _petService = petService;
            _ownerService = ownerService;
        }

        public async Task<IActionResult> Index()
        {
            var pets = await _petService.GetAllPetsAsync();
            return View(pets);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pet = await _petService.GetPetByIdAsync(id.Value);
            if (pet == null) return NotFound();

            return View(pet);
        }

        public async Task<IActionResult> Create()
        {
            var owners = await _ownerService.GetAllOwnersAsync();
            ViewData["OwnerId"] = new SelectList(owners, "Id", "LastName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OwnerId,Species,Breed,BirthTime,CreatedAt,DeletedAt")] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                var owners = await _ownerService.GetAllOwnersAsync();
                ViewData["OwnerId"] = new SelectList(owners, "Id", "LastName", pet.OwnerId);
                return View(pet);
            }

            await _petService.AddPetAsync(pet);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pet = await _petService.GetPetByIdAsync(id.Value);
            if (pet == null) return NotFound();

            var owners = await _ownerService.GetAllOwnersAsync();
            ViewData["OwnerId"] = new SelectList(owners, "Id", "LastName", pet.OwnerId);
            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OwnerId,Species,Breed,BirthTime,CreatedAt,DeletedAt")] Pet pet)
        {
            if (id != pet.Id) return NotFound();
            if (!ModelState.IsValid)
            {
                var owners = await _ownerService.GetAllOwnersAsync();
                ViewData["OwnerId"] = new SelectList(owners, "Id", "LastName", pet.OwnerId);
                return View(pet);
            }

            await _petService.UpdatePetAsync(pet);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pet = await _petService.GetPetByIdAsync(id.Value);
            if (pet == null) return NotFound();

            return View(pet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _petService.DeletePetAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}