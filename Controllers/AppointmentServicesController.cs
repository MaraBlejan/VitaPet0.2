using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VitaPet0._2.Models;
using VitaPet0._2.Services;

namespace VitaPet0._2.Controllers
{
    public class AppointmentServicesController : Controller
    {
        private readonly IAppointmentLinkService _appointmentLinkService;
        private readonly IAppointmentBusinessService _appointmentBusinessService;
        private readonly IServiceService _serviceService;

        public AppointmentServicesController(IAppointmentLinkService appointmentLinkService, IAppointmentBusinessService appointmentBusinessService, IServiceService serviceService)
        {
            _appointmentLinkService = appointmentLinkService;
            _appointmentBusinessService = appointmentBusinessService;
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index() => View(await _appointmentLinkService.GetAllAppointmentServicesAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _appointmentLinkService.GetAppointmentServiceByIdAsync(id.Value);
            if (item == null) return NotFound();
            return View(item);
        }

        public async Task<IActionResult> Create()
        {
            var appointments = await _appointmentBusinessService.GetAllAppointmentsAsync();
            var services = await _serviceService.GetAllServicesAsync();
            ViewData["AppointmentId"] = new SelectList(appointments, "Id", "Id");
            ViewData["ServiceId"] = new SelectList(services, "Id", "ServicesName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppointmentId,ServiceId,CreatedAt,DeletedAt")] AppointmentService appointmentServiceModel)
        {
            if (!ModelState.IsValid)
            {
                var appointments = await _appointmentBusinessService.GetAllAppointmentsAsync();
                var services = await _serviceService.GetAllServicesAsync();
                ViewData["AppointmentId"] = new SelectList(appointments, "Id", "Id", appointmentServiceModel.AppointmentId);
                ViewData["ServiceId"] = new SelectList(services, "Id", "ServicesName", appointmentServiceModel.ServiceId);
                return View(appointmentServiceModel);
            }

            await _appointmentLinkService.AddAppointmentServiceAsync(appointmentServiceModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _appointmentLinkService.GetAppointmentServiceByIdAsync(id.Value);
            if (item == null) return NotFound();

            var appointments = await _appointmentBusinessService.GetAllAppointmentsAsync();
            var services = await _serviceService.GetAllServicesAsync();
            ViewData["AppointmentId"] = new SelectList(appointments, "Id", "Id", item.AppointmentId);
            ViewData["ServiceId"] = new SelectList(services, "Id", "ServicesName", item.ServiceId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppointmentId,ServiceId,CreatedAt,DeletedAt")] AppointmentService appointmentServiceModel)
        {
            if (id != appointmentServiceModel.Id) return NotFound();
            if (!ModelState.IsValid)
            {
                var appointments = await _appointmentBusinessService.GetAllAppointmentsAsync();
                var services = await _serviceService.GetAllServicesAsync();
                ViewData["AppointmentId"] = new SelectList(appointments, "Id", "Id", appointmentServiceModel.AppointmentId);
                ViewData["ServiceId"] = new SelectList(services, "Id", "ServicesName", appointmentServiceModel.ServiceId);
                return View(appointmentServiceModel);
            }

            await _appointmentLinkService.UpdateAppointmentServiceAsync(appointmentServiceModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _appointmentLinkService.GetAppointmentServiceByIdAsync(id.Value);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentLinkService.DeleteAppointmentServiceAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}