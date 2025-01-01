using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management.Models;
using Task_Management.Models.repo.internalinterface;

namespace Task_Management.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _context;
        public UserController(IUser user)
        {
            _context = user;
                
        }
        public async Task<ActionResult> Getall()
        {
            var mo=await _context.GetAll();
            return View(mo);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var se=await _context.Details(id);  
            return View(se);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            await _context.Create(user);
            return RedirectToAction("Getall");
            
        }

        // GET: UserController/Edit/5
        public async  Task<ActionResult> Edit(int id)
        {
            var mo = await _context.Details(id);
            return View(mo);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( User user)
        {
            await _context.Update(user);
            return RedirectToAction("Getall");
        }

        // GET: UserController/Delete/5
        public async   Task<ActionResult> Delete(int id)
        {
            var mo = await _context.Details(id);
            return View(mo);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(User user)
        {
           await _context.Delete(user);
            return RedirectToAction("Getall");
        }
    }
}
