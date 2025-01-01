using Hospitall.Models.ropis.Iropis;
using Hospitall.Models.viewModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace Hospitall.Models.ropis
{
    public class rappo : Iappoin
    {
        private readonly appdbcontext _context;
        public rappo(appdbcontext appdbcontext)
        {
            _context = appdbcontext;

        }
        async Task Iappoin.create(appoviewModel model)
        {
            var app = new Appointment()
            {

                Date = model.Date,
                notes = model.notes,
                PatId = model.PatId,
                DoctId = model.DoctId,

            };
            await _context.appointments.AddAsync(app);
            await _context.SaveChangesAsync();
        }

        async Task Iappoin.delete(Appointment appointment)
        {
            _context.appointments.Remove(appointment);
            await _context.SaveChangesAsync();

        }

        async Task<Appointment> Iappoin.Details(int Id)
        {
            var mo = await _context.appointments.Include(t=>t.Doctor).Include(o=>o.Patient).FirstOrDefaultAsync(y => y.Id == Id);
            return mo;
        }

        async Task<ICollection<Appointment>> Iappoin.Getall()
        {
            var s = await _context.appointments.Include(u => u.Doctor).Include(i => i.Patient).ToListAsync();
            return s;
        }
        async Task<Appointment> Iappoin.update(appoviewModel model)
        {
            var app = new Appointment()
            {

                Date = model.Date,
                notes = model.notes,
                PatId = model.PatId,
                DoctId = model.DoctId,

            };
             _context.appointments.Update(app);
            await _context.SaveChangesAsync();
            return app;

        }
    }
}
