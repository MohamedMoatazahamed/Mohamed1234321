using Hospitall.Models;
using Hospitall.Models.ropis.Iropis;
using Hospitall.Models.viewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospitall.Controllers
{
    public class appoController1 : Controller
    {
        private readonly Iappoin db;
        private readonly IDoctor doctor;
        private readonly ipatent pat;

        public appoController1(Iappoin iappoin, IDoctor doctor1,ipatent ipatent)
        {
            db= iappoin;
            doctor= doctor1;
            pat= ipatent;  
        }

        public async Task<IActionResult> Getall()
        {
            var get = await db.Getall();
            return View(get);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            appoviewModel model = new appoviewModel();
            var patient = await pat.Getall();
            if (patient == null) return View("Getall");

            var Doc = await doctor.Getall();
            if (Doc == null) return View("Getall");

            model.patients = patient;
            model.Doctors = Doc;

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> create(appoviewModel model)
        {
            
                await db.create(model);

                return RedirectToAction("Getall");

            

        }



        [HttpGet]
        public async Task<IActionResult> Update()
        {
            appoviewModel model = new appoviewModel();
            var patient = await pat.Getall();
            if (patient == null) return View("Getall");

            var Doc = await doctor.Getall();
            if (Doc == null) return View("Getall");

            model.patients = patient;
            model.Doctors = Doc;

            return View(model);
          
        }
        [HttpPost]

        public async Task<IActionResult> Update(appoviewModel model)
        {

            
                await db.update(model);
           
            return RedirectToAction("Getall");
        }

       
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var op = await db.Details(id);
            return View(op);

        }
        [HttpPost]

        public async Task<IActionResult> Delete(Appointment appointment)
        {
            await db.delete(appointment);
            return RedirectToAction("Getall");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var op = await db.Details(id);
            return View(op);
        }


    }


}
