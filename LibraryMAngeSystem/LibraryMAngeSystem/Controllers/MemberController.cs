using LibraryMAngeSystem.Models;
using LibraryMAngeSystem.Models.rop.internalinterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMAngeSystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMember context;
        public MemberController(IMember member)
        {
            this.context = member;
            
        }
        // GET: MemberController1
        public async       Task<ActionResult> GetAll()
        {
           var ni=await  context.GetAll();
            return View(ni);
        }

        // GET: MemberController1/Details/5
        public async         Task<ActionResult> Details(int id)
        {
           var mo=await context.Details(id);
            return View(mo);
        }

        // GET: MemberController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Member member)
        {
            await context.Craete(member);
            return RedirectToAction("GetAll");
            
        }

        // GET: MemberController1/Edit/5
        public async  Task<ActionResult> Edit(int id)
        {
            var mo = await context.Details(id);
            return View(mo);
        }

        // POST: MemberController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Member member)
        {
            await context.Update(member);
            return RedirectToAction("GetAll");
            
        }

        // GET: MemberController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var mo = await context.Details(id);
            return View(mo);
        
        }

        // POST: MemberController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(Member member)
        {
            await context.Delete(member);
            return RedirectToAction("GetAll");
           
        }
    }
}
