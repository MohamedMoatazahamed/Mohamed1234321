using Microsoft.EntityFrameworkCore;
using schoolsystem.Controllers;
using schoolsystem.Models.repos.internalinterface;

namespace schoolsystem.Models.repos.rop
{
    public class rstudent : IStudent
    {
        private readonly appdbcontext _context;
            public rstudent(appdbcontext appdbcontext)
        {
            _context = appdbcontext;
                
        }
        async  Task IStudent.Creat(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            
        }

     

       async Task IStudent.Delete(Student student)
        {
             _context.Students.Remove(student);
                _context.SaveChanges();
           
        }

        async Task<Student> IStudent.Details(int id)
        {
           var search=await _context.Students.FindAsync(id);
            return search;
        }

        async Task<ICollection<Student>> IStudent.Getall()
        {
            var get = await _context.Students.ToListAsync();
            return get;
        } 

        async Task<Student> IStudent.Update(Student student, int id)
        {
            var mo=await _context.Students.FirstOrDefaultAsync(s=>s.id==id);
            mo.StuName=student.StuName;
            mo.Age=student.Age;
            mo.Gendr=student.Gendr;
             _context.Students.Update(mo);
            await _context.SaveChangesAsync();
            return mo;

         
        }
    }
}
