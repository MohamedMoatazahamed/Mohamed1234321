using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schoolsystem.Models;
using schoolsystem.Models.repos.internalinterface;

namespace schoolsystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _context;
        public StudentController(IStudent student)
        {
            _context = student;
            
        }
        public async Task<ActionResult> Getall()
        {
            var n=await _context.Getall();
            return  View(n);

        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
         var xy= await _context.Details(id);
            return View(xy);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
                _context.Creat(student);
            return RedirectToAction("Getall");
        }

        [HttpGet]
        public async  Task<ActionResult> Edit(int id)
        {
            var sear = await _context.Details(id);
            return View(sear);
        }

      
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Student student)
        {
            var up= await _context.Update(student,id);
            return RedirectToAction("Getall");


          
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var st=await _context.Details(id);
            return View(st);
           
        }

     
        [HttpPost]
        public async Task<ActionResult> Delete(Student student)
        {
           await _context.Delete(student);
            return RedirectToAction("Getall");

            
        }
    }
}
