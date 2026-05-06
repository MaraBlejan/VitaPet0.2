using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VitaPet0._2.Models;
using VitaPet0._2.Services;

namespace VitaPet0._2.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService) => _doctorService = doctorService;

        public async Task<IActionResult> Index() => View(await _doctorService.GetAllDoctorsAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var doctor = await _doctorService.GetDoctorByIdAsync(id.Value);
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Specialization,Email,CreatedAt,DeletedAt")] Doctor doctor)
        {
            if (!ModelState.IsValid) return View(doctor);
            await _doctorService.AddDoctorAsync(doctor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var doctor = await _doctorService.GetDoctorByIdAsync(id.Value);
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Specialization,Email,CreatedAt,DeletedAt")] Doctor doctor)
        {
            if (id != doctor.Id) return NotFound();
            if (!ModelState.IsValid) return View(doctor);
            await _doctorService.UpdateDoctorAsync(doctor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var doctor = await _doctorService.GetDoctorByIdAsync(id.Value);
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}