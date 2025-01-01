using Hospitall.Models;
using Hospitall.Models.ropis;
using Hospitall.Models.ropis.Iropis;
using Microsoft.AspNetCore.Mvc;

namespace Hospitall.Controllers
{
    public class PatentController1 : Controller
    {
        private readonly ipatent db;
        public PatentController1(ipatent ipatent)
        {
            db = ipatent;
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
        public async Task<IActionResult> create(Patient patient)
        {

            await db.create(patient);
            return RedirectToAction("Getall");
        }






        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            var use = await db.Details(id);
            return View(use);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Patient patient)
        {

            await db.delete(patient);
            return RedirectToAction("Getall");

        }
        [HttpGet]
        async public Task<IActionResult> update(int id)
        {
            var patient = await db.Details(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }
        [HttpPost]
        public async Task<IActionResult> update(Patient patient,int id)
        {

            var noi = await db.update(patient,id);

            return RedirectToAction("Getall");

        }






    }
}
