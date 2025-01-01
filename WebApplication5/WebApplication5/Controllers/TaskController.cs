using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication5.Models;
using WebApplication5.Models.viewmodel;

namespace WebApplication5.Controllers
{
    public class TaskController : Controller
    {
        private readonly appdbcontext _context;
        public TaskController(appdbcontext appdbcontext)
        {
            _context = appdbcontext;
            
        }
        // GET: TaskController
        public async Task<ActionResult> Index()
        {
            var mo=await _context.tasks.ToListAsync();
            return View(mo);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public async  Task<ActionResult> Edit12(int id)
        {
            var mo = await _context.projects.ToListAsync();
            var ni= await _context.teamMembers.ToListAsync();
            taskviewmodel model = new taskviewmodel()
            {
                projects = mo,
                teamMembers = ni
            };
            return View(model);
            
        }

        // POST: TaskController/Edit/5
        [HttpPost]
 
     public async  Task<ActionResult> Edit12(int id,taskviewmodel model)
        {
           var mo = await _context.tasks.FirstOrDefaultAsync(i=>i.Id == id);
            mo.Id = model.Id;
            mo.Description= model.Description;
            mo.Title= model.Title;
            mo.Priority= model.Priority;
            mo.Status= model.Status;
            mo.projectID = model.projectID;
            mo.TeamId = model.TeamId;
            mo.Deadline= model.Deadline;
             
            _context.tasks.Update(mo);
            _context.SaveChanges();
            return RedirectToAction("Index","Project");


        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
