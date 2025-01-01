using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using schoolsystem.Models.repos.internalinterface;

namespace schoolsystem.Models.repos.rop
{
    public class rteather : Iteather
    {
        private readonly appdbcontext _context;
        public rteather(appdbcontext co)
        {
            _context = co;
            
        }

        async Task Iteather.Create(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            _context.SaveChanges();
        
        }

        async Task Iteather.Delete(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }

        async Task<Teacher> Iteather.Detals(int id)
        {
            var ser = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == id);
            return ser;
           
        }

        async Task<ICollection<Teacher>> Iteather.Getall()
        {
            var git = await _context.Teachers.ToListAsync();
            return git;
           
        }

    async    Task<Teacher> Iteather.Update(Teacher teacher, int id)
        {
            var ser = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == id);
            ser.Name=teacher.Name;
            ser.Subject=teacher.Subject;
          _context.Teachers.Update(ser);
            _context.SaveChanges();
            return ser;



        }
    }
}
