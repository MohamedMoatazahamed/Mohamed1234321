using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schoolsystem.Models;
using schoolsystem.Models.repos.internalinterface;

namespace schoolsystem.Controllers
{
    public class TeacherController : Controller
    {
       private readonly Iteather context;
        public TeacherController(Iteather iteather)
        {
            this.context = iteather;
                
        }
   
    
        public async Task<ActionResult> GatAll()
        {
            var n = await context.Getall();
            return View(n);
        }

        // GET: TeachersController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var nu=await context.Detals(id);
            return View(nu);
        }

        // GET: TeachersController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeachersController1/Create
        [HttpPost]
    
        public async Task<ActionResult> Create(Teacher teacher)
        {
            await context.Create(teacher);
            return RedirectToAction("GatAll");
        }

        // GET: TeachersController1/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var sear = await context.Detals(id);
            return View(sear);
        }

     
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Teacher teacher)
        {
         await context.Update(teacher, id);
            return RedirectToAction("GatAll");

          
        }


        public async  Task<ActionResult> Delete(int id)
        {
           var ser= await context.Detals(id);
            return View(ser);   
        }


        [HttpPost]
        public async Task<ActionResult> Delete(Teacher teacher)
        {
               await context.Delete(teacher);
            return RedirectToAction("GatAll");

        }
    }
}
