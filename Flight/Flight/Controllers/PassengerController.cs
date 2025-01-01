using FlightSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightSystem.Controllers
{
    public class PassengerController : Controller
    {
        private readonly appdbcontext _context;
        public PassengerController(appdbcontext appdbcontext)
        {
            _context = appdbcontext;
                
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Getall() 
        {
            var mo=await _context.passengers.ToListAsync();
            return View(mo);
        }
        public async Task<IActionResult> Details(int id)
        {
            var set=await _context.passengers.FindAsync(id);
            return View(set);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
             return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Passenger passenger)
        {
            await _context.passengers.AddAsync(passenger);
            await _context.SaveChangesAsync();
            return RedirectToAction("Getall");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var nu= await _context.passengers.FirstOrDefaultAsync(i=>i.Id==id);
            return View(nu);

        }
        [HttpPost]
        public async Task<IActionResult> Update(Passenger passenger)
        {
            _context.passengers.Update(passenger);
            await _context.SaveChangesAsync();
            return RedirectToAction("Getall");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ui = await _context.passengers.FindAsync(id);
            return View(ui);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Passenger passenger)
        {
            _context.passengers.Remove(passenger);
            await _context.SaveChangesAsync();
            return RedirectToAction("Getall");
        }


    }
}
