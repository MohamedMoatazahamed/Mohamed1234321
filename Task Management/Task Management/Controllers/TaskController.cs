using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management.Models;
using Task_Management.Models.repo.internalinterface;
using Task_Management.Models.viewModel;

namespace Task_Management.Controllers
{
    public class TaskController : Controller
    {
        private readonly IUser user;
        private readonly ITask _context;
        public TaskController(ITask task,IUser user)
        {
            this.user = user;
            this._context = task;
            
        }
        public async Task< ActionResult> Getall()
        {
            var git=await _context.GetAll();
            return View(git);
        }

        // GET: TaskController/Details/5
        public async   Task<ActionResult> Details(int id)
        {
           var de=await _context.Details(id);
            return View(de);
        }

        // GET: TaskController/Create
       async public Task<ActionResult> Create()
        {
           viewModelTask task = new viewModelTask();
            var user1 = await user.GetAll(); if (user1 == null) return View("GetAll");
          task.users = user1;
            return View(task);
         
        }

        // POST: TaskController/Create
        [HttpPost]
    
        public async Task<ActionResult> Create(viewModelTask viewModelTask)
        {
            await _context.Create(viewModelTask);
            return RedirectToAction("GetAll");
       
        }

        // GET: TaskController/Edit/5
       async public Task<ActionResult> Edit(int id)
        {
            viewModelTask task = new viewModelTask();
            var user1 = await user.GetAll(); if (user1 == null) return View("GetAll");
            task.users = user1;
            return View(task);

        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult>Edit(viewModelTask modelTask)
        {
           await _context.Update(modelTask);
            return View(modelTask);
        }

        // GET: TaskController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var mo = await _context.Details(id);
            return View(mo);
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(Task1 task)
        {
           await _context.Delete(task);
            return RedirectToAction("GetAll");
        }
    }
}
