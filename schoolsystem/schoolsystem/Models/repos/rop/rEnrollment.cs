using Microsoft.EntityFrameworkCore;
using schoolsystem.Models.repos.internalinterface;
using schoolsystem.Models.viewmodel;

namespace schoolsystem.Models.repos.rop
{
    public class rEnrollment : IEnrollment
    {
        private readonly appdbcontext context;
        public rEnrollment(appdbcontext appdbcontext)
        {
            this.context = appdbcontext;
            
        }
        async Task IEnrollment.Create(Enrollmentviewmodel model)
        {
            var Enro = new Enrollment
            {
                classId = model.classId,
                teatherID = model.teatherID,
                Enroll = model.Enroll,
                studentId = model.studentId,


            };
            await context.AddAsync(Enro);
            context.SaveChanges();


        }

        async Task IEnrollment.Delete(Enrollment enrollment)
        {
             context.Enrollments.Remove(enrollment);
            context.SaveChanges();
           
        }

     async   Task<Enrollment> IEnrollment.Details(int id)
        {
            var git1 = await context.Enrollments.Include(r => r.class1).Include(j => j.Teacher).Include(g => g.student).FirstOrDefaultAsync(o=>o.Id == id);
            return git1;

        }

        async Task<ICollection<Enrollment>> IEnrollment.GetAll()
        {
            var git=await context.Enrollments.Include(r=>r.class1).Include(j=>j.Teacher).Include(g=>g.student).ToListAsync();
            return git;
        }

        async Task<Enrollment> IEnrollment.Update(Enrollmentviewmodel model)
        {
            var Enro = new Enrollment
            {
                classId = model.classId,
                teatherID = model.teatherID,
                Enroll = model.Enroll,
                studentId = model.studentId,


            };
            context.Enrollments.Update(Enro);
            await context.SaveChangesAsync();
            return Enro;


        }
    }
}
