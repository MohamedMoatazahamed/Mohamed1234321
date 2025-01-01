using LibraryMAngeSystem.Models;
using LibraryMAngeSystem.Models.rop.internalinterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMAngeSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _context;
        public BookController(IBook book)
        {
            _context = book;
            
        }

        public async  Task<ActionResult> GetAll()
        {
            var git = await _context.GetAll();
            return View(git);
        }

        public async Task<ActionResult> Details(int id)
        {
            var set=await _context.Deatails(id);
            return View(set);
            
        }

       
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
   
        public async Task<ActionResult> Create(Book book)
        {
            await _context.Create(book);
            return RedirectToAction("GetAll");
           
        }

      
        public async Task<ActionResult> Edit(int id)
        {
            var vu = await _context.Deatails(id);
            return View(vu);
        }


        [HttpPost]
     
        public async  Task<ActionResult>  Edit(Book book)
        {
           await _context.Update(book);
            return RedirectToAction("GetAll");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var vu1 = await _context.Deatails(id);
            return View(vu1);
        
        }

   
        [HttpPost]
    
        public async Task<ActionResult> Delete(Book book)
        {
            await _context.Delete(book);
            return RedirectToAction("GetAll");
            
        }
    }
}
