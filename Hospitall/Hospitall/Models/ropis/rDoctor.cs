using Hospitall.Models.ropis.Iropis;
using Microsoft.EntityFrameworkCore;

namespace Hospitall.Models.ropis
{
    public class rDoctor : IDoctor
    {
        private readonly appdbcontext _context;
        public rDoctor(appdbcontext qw)
        {
            _context = qw;
                
        }
      async Task IDoctor.create(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            _context.SaveChanges();  
        }

        async Task IDoctor.delete(Doctor doctor)
        {
             _context.Doctors.Remove(doctor);
            _context.SaveChanges();
           
        }

        async Task<Doctor> IDoctor.Details(int Id)
        {
            var mo =  _context.Doctors.FirstOrDefault(y=>y.DocID==Id);
            return mo;
        }

        async  Task<ICollection<Doctor>> IDoctor.Getall()
        {
            var Doctors1 =await _context.Doctors.ToListAsync();
            return Doctors1;
        }

   async Task<Doctor> IDoctor.update(int id,Doctor doctor)
        {
            var edit = await _context.Doctors.FindAsync(id);
            edit.Name=doctor.Name;
            edit.Specialty=doctor.Specialty;
            _context.Doctors.Update(edit);
            _context.SaveChanges();
            return edit;
        }
    }
}
