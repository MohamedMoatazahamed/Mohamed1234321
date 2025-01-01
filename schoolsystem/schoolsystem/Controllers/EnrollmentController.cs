using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using schoolsystem.Models;
using schoolsystem.Models.repos.internalinterface;
using schoolsystem.Models.viewmodel;

namespace schoolsystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollment Context
             ;
        private readonly IStudent students ;
        private readonly Iteather teather ;
        private readonly Iclass iclasss;
        public EnrollmentController(IEnrollment enrollment,IStudent student,Iteather iteathe,Iclass iclass)
        {

            Context = enrollment ;
            students = student ; 
            teather = iteathe ;
            iclasss = iclass;


                
        }
        public async   Task<ActionResult> Getall()
        {
            var git = await Context.GetAll();
            return View (git);
           
        }

        // GET: HomeController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var sa=await Context.Details(id);
            return View (sa);
           
        }

        // GET: HomeController1/Create
        [HttpGet]
        public async  Task<ActionResult> Create()
        {
            Enrollmentviewmodel model = new Enrollmentviewmodel();
           var st=await students.Getall();
        
            var tea = await teather.Getall();
       
            var ic = await iclasss.Getall();
       

            model.teacherList = tea;
            model.StudentList=st;
            model.ClassList=ic;
            return View(model);
        }

        // POST: HomeController1/Create
        [HttpPost]
      
        public async Task<ActionResult> Create(Enrollmentviewmodel model)
        {
           await Context.Create(model);
            return RedirectToAction("GetAll");
        }

        // GET: HomeController1/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Enrollmentviewmodel model = new Enrollmentviewmodel();
            var st = await students.Getall();if(st == null) return View("Getall");
            var teat = await teather.Getall();if(teat == null) return View("Getall");
            var iclas=  await iclasss.Getall();if(iclas==null) return View("Getall");
            model.teacherList = teat;
            model.StudentList=st;
            model.ClassList=iclas;
            return View(model);

      
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
 
        public async Task<ActionResult> Edit( Enrollmentviewmodel model)
        {
            await Context.Update(model);
            return RedirectToAction("GetAll");
           
        }

        // GET: HomeController1/Delete/5
        public async  Task<ActionResult> Delete(int id)
        {
            var ni = await Context.Details(id);
            return View(ni);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
   
        public async Task<ActionResult> Delete(Enrollment enrollment)
        {
            await Context.Delete(enrollment);
            return RedirectToAction("GetAll");
        }
    }
}
