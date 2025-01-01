using Hospitall.Models.ropis.Iropis;
using Microsoft.EntityFrameworkCore;

namespace Hospitall.Models.ropis
{
    public class rpatent : ipatent
    {
        private readonly appdbcontext _context;
        public rpatent(appdbcontext appdbcontext)
        {
            _context = appdbcontext;
                
        }

      async  public Task<Patient> Details(int Id)
        {
            var p = await _context.Patients.FirstOrDefaultAsync(o => o.PatId == Id);
            return p;
        }

        async Task ipatent.create(Patient patient)
        {
         await _context.AddAsync(patient);
         await _context.SaveChangesAsync();
        }

        async Task ipatent.delete(Patient patient)
        {
           _context.Patients.Remove(patient);    
            await _context.SaveChangesAsync();
        }

        async Task<ICollection<Patient>> ipatent.Getall()
        {
          var pats=await _context.Patients.ToListAsync();
            return pats;    
        }

        async Task<Patient> ipatent.update(Patient patient,int id)
        {
            var a = await _context.Patients.FindAsync(id);
            a.PatName=patient.PatName;
            a.Age=patient.Age;
            a.Gender=patient.Gender;
            _context.Patients.Update(a);
            await _context.SaveChangesAsync();
            return patient;
        }
    }
}
