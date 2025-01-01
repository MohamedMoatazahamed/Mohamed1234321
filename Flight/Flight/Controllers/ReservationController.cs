using FlightSystem.Models;
using FlightSystem.Models.viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly appdbcontext _context;
        public ReservationController(appdbcontext appdbcontext)
        {
            _context = appdbcontext;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Getall()
        {
            var mo = await _context.reservations.Include(i => i.Passenger).Include(u => u.Flight).ToListAsync();
            return View(mo);
        }
        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            var mo = await _context.flights.ToListAsync();
            var mi = await _context.passengers.ToListAsync();
            Reservationviewmodel model = new Reservationviewmodel()
            {
                flights = mo,
                passengers = mi,
            };
      
            return View(model);



        }
        [HttpPost]
        public async Task<IActionResult> Create(Reservationviewmodel model)
        {
            Reservation reservation = new Reservation()
            {
             
                FlightId = model.FlightId,
                PassengerId = model.PassengerId,
                Status = model.Status,
                ReservationDate = model.ReservationDate,

            };
            _context.reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction("Getall");
        }
        [HttpGet]
        public async Task<IActionResult> update(int id)
        {
            var mo = await _context.flights.ToListAsync();
            var mi = await _context.passengers.ToListAsync();
            Reservationviewmodel model = new Reservationviewmodel();
            model.flights = mo;
            model.passengers = mi;
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> update(Reservationviewmodel model)
        {
            Reservation reservation = new Reservation()
            {
                Id = model.Id,
                FlightId = model.FlightId,
                PassengerId = model.PassengerId,
                Status = model.Status,
                ReservationDate = model.ReservationDate,

            };
            _context.reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Getall");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var mo = await _context.reservations.FindAsync(id);
            return View(mo);

        }
        public async Task<IActionResult> Delete(Reservation reservation)
        {
            _context.reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Getall");





        }

    }
}
