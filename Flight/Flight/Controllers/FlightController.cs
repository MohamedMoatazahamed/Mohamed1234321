using FlightSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightSystem.Controllers
{
    public class FlightController : Controller
    {
        private readonly appdbcontext _context;
        public FlightController(appdbcontext appdbcontext)
        {
            _context = appdbcontext;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Getall()
        {
            var sr = await _context.flights.ToListAsync();
            return View(sr);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Flight flight)
        {
            await _context.flights.AddAsync(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction("Getall");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var b = await _context.flights.FindAsync(id);
            return View(b);

        }
        [HttpPost]
        public async Task<IActionResult> Update(Flight flight)
        {
             _context.flights.Update(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction("Getall");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var b1 = await _context.flights.FindAsync(id);
            return View(b1);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Flight flight)
        {
            _context.flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction("Getall");
        }

    }
}
