using LibraryMAngeSystem.Models;
using LibraryMAngeSystem.Models.rop.internalinterface;
using LibraryMAngeSystem.Models.viewmodel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMAngeSystem.Controllers
{
    public class BorrowRecorController : Controller
    {
       private readonly IBorrowRecord context;
        private readonly IBook book;
        private readonly IMember member;

        public BorrowRecorController( IMember member,IBook book,IBorrowRecord borrowRecord)
        {

            this.member = member;
            this.book = book;
            this.context = borrowRecord;
         
            
        }
        public async  Task<ActionResult> GetAll()
        {
            var nu=await context.GetAll();
            return View(nu);
        }

        // GET: BorrowRecorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var n=await context.Details(id);
            return View(n);
        }

        // GET: BorrowRecorController/Create
        public async Task<ActionResult> Create()
        {
            BorrowRecordviewModel Model = new BorrowRecordviewModel();
            var Bo = await book.GetAll();
            
            if (Bo == null) return View("GetAll");
       
            var mem=await member.GetAll();if (mem == null) return View("GetAll");
            Model.members = mem;
            Model.books=Bo;
            return View(Model);

        }

        // POST: BorrowRecorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async        Task<ActionResult> Create(BorrowRecordviewModel model)
        {
            await context.Create(model);
            return RedirectToAction("GetAll");

        }

        // GET: BorrowRecorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
      
            var Model = new BorrowRecordviewModel();
            var Bo = await book.GetAll(); if (Bo == null) return View("GetAll");
            var mem = await member.GetAll(); if (mem == null) return View("GetAll");
            Model.members = mem;
            Model.books = Bo;
            return View(Model);

        }

        // POST: BorrowRecorController/Edit/5
        [HttpPost]
  
        public  ActionResult Edit(BorrowRecordviewModel model)
        {
             context.update(model);
            return RedirectToAction("GetAll");

        }

        // GET: BorrowRecorController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var ni = await context.Details(id);
            return View(ni);
        }

        // POST: BorrowRecorController/Delete/5
        [HttpPost]
     
        public async Task<ActionResult> Delete(BorrowRecord borrowRecord)
        {
           await context.Delete(borrowRecord);
            return RedirectToAction("GetAll");
        }
    }
}
