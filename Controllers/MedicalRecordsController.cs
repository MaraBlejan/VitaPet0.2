using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VitaPet0._2.Models;
using VitaPet0._2.Services;

namespace VitaPet0._2.Controllers
{
    public class MedicalRecordsController : Controller
    {
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IDoctorService _doctorService;
        private readonly IPetService _petService;

        public MedicalRecordsController(IMedicalRecordService medicalRecordService, IDoctorService doctorService, IPetService petService)
        {
            _medicalRecordService = medicalRecordService;
            _doctorService = doctorService;
            _petService = petService;
        }

        public async Task<IActionResult> Index() => View(await _medicalRecordService.GetAllMedicalRecordsAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var record = await _medicalRecordService.GetMedicalRecordByIdAsync(id.Value);
            if (record == null) return NotFound();
            return View(record);
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
        public async Task<IActionResult> Create([Bind("Id,DoctorId,PetId,Diagnosis,Date,CreatedAt,DeletedAt")] MedicalRecord medicalRecord)
        {
            if (!ModelState.IsValid)
            {
                var doctors = await _doctorService.GetAllDoctorsAsync();
                var pets = await _petService.GetAllPetsAsync();
                ViewData["DoctorId"] = new SelectList(doctors, "Id", "LastName", medicalRecord.DoctorId);
                ViewData["PetId"] = new SelectList(pets, "Id", "Breed", medicalRecord.PetId);
                return View(medicalRecord);
            }

            await _medicalRecordService.AddMedicalRecordAsync(medicalRecord);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var record = await _medicalRecordService.GetMedicalRecordByIdAsync(id.Value);
            if (record == null) return NotFound();

            var doctors = await _doctorService.GetAllDoctorsAsync();
            var pets = await _petService.GetAllPetsAsync();
            ViewData["DoctorId"] = new SelectList(doctors, "Id", "LastName", record.DoctorId);
            ViewData["PetId"] = new SelectList(pets, "Id", "Breed", record.PetId);
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,PetId,Diagnosis,Date,CreatedAt,DeletedAt")] MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.Id) return NotFound();
            if (!ModelState.IsValid)
            {
                var doctors = await _doctorService.GetAllDoctorsAsync();
                var pets = await _petService.GetAllPetsAsync();
                ViewData["DoctorId"] = new SelectList(doctors, "Id", "LastName", medicalRecord.DoctorId);
                ViewData["PetId"] = new SelectList(pets, "Id", "Breed", medicalRecord.PetId);
                return View(medicalRecord);
            }

            await _medicalRecordService.UpdateMedicalRecordAsync(medicalRecord);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var record = await _medicalRecordService.GetMedicalRecordByIdAsync(id.Value);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _medicalRecordService.DeleteMedicalRecordAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}