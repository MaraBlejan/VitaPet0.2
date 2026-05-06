using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VitaPet0._2.Models;
using VitaPet0._2.Services;

namespace VitaPet0._2.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentBusinessService _appointmentBusinessService;
        private readonly IDoctorService _doctorService;
        private readonly IPetService _petService;

        public AppointmentsController(IAppointmentBusinessService appointmentBusinessService, IDoctorService doctorService, IPetService petService)
        {
            _appointmentBusinessService = appointmentBusinessService;
            _doctorService = doctorService;
            _petService = petService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _appointmentBusinessService.GetAllAppointmentsAsync();
            return View(items);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var appointment = await _appointmentBusinessService.GetAppointmentByIdAsync(id.Value);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        public async Task<IActionResult> Create()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var pets = await _petService.GetAllPetsAsync();
            ViewData["DoctorId"] = new SelectList(doctors, "Id", "LastName");
            ViewData["PetId"] = new SelectList(pets, "Id", "Breed");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PetId,DoctorId,AppointmentDate,Status,CreatedAt,DeletedAt")] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                var doctors = await _doctorService.GetAllDoctorsAsync();
                var pets = await _petService.GetAllPetsAsync();
                ViewData["DoctorId"] = new SelectList(doctors, "Id", "LastName", appointment.DoctorId);
                ViewData["PetId"] = new SelectList(pets, "Id", "Breed", appointment.PetId);
                return View(appointment);
            }

            await _appointmentBusinessService.AddAppointmentAsync(appointment);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var appointment = await _appointmentBusinessService.GetAppointmentByIdAsync(id.Value);
            if (appointment == null) return NotFound();

            var doctors = await _doctorService.GetAllDoctorsAsync();
            var pets = await _petService.GetAllPetsAsync();
            ViewData["DoctorId"] = new SelectList(doctors, "Id", "LastName", appointment.DoctorId);
            ViewData["PetId"] = new SelectList(pets, "Id", "Breed", appointment.PetId);
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PetId,DoctorId,AppointmentDate,Status,CreatedAt,DeletedAt")] Appointment appointment)
        {
            if (id != appointment.Id) return NotFound();
            if (!ModelState.IsValid)
            {
                var doctors = await _doctorService.GetAllDoctorsAsync();
                var pets = await _petService.GetAllPetsAsync();
                ViewData["DoctorId"] = new SelectList(doctors, "Id", "LastName", appointment.DoctorId);
                ViewData["PetId"] = new SelectList(pets, "Id", "Breed", appointment.PetId);
                return View(appointment);
            }

            await _appointmentBusinessService.UpdateAppointmentAsync(appointment);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var appointment = await _appointmentBusinessService.GetAppointmentByIdAsync(id.Value);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentBusinessService.DeleteAppointmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}