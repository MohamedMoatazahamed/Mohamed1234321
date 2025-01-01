using Hospitall.Models.ropis.Iropis;
using Hospitall.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospitall.Controllers
{
    public class DoctorController1 : Controller
    {
        private readonly IDoctor db;
        public DoctorController1(IDoctor doctor)
        {
            db = doctor;
        }

        public async Task<IActionResult> Getall()
        {
            var patie = await db.Getall();
            return View(patie);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(Doctor doctor)
        {
            await db.create(doctor);
            return RedirectToAction("Getall");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var use = await db.Details(id);
            return View(use);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Doctor doctor)
        {

            await db.delete(doctor);
            return RedirectToAction("Getall");

        }
        [HttpGet]
        public IActionResult update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> update(Doctor doctor,int ID)
        {
            var noi = await db.update(ID,doctor);
            return RedirectToAction("Getall");
        }
    }
}
