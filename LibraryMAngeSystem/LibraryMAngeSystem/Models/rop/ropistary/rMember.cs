using LibraryMAngeSystem.Models.rop.internalinterface;
using Microsoft.EntityFrameworkCore;

namespace LibraryMAngeSystem.Models.rop.ropistary
{
    public class rMember : IMember
    {
        private readonly appdbcontext context;
        public rMember(appdbcontext appdbcontext)
        {
            this.context = appdbcontext;
                
        }
        async Task IMember.Craete(Member member)
        {
           await context.members.AddAsync(member);
            await context.SaveChangesAsync();
        }

        async Task IMember.Delete(Member member)
        {
             context.members.Remove(member);
            await context.SaveChangesAsync();
        }

        async Task<Member> IMember.Details(int id)
        {
           var no=await context.members.FindAsync(id);
            return no;
        }

        async Task<ICollection<Member>> IMember.GetAll()
        {
            var git=await context.members.ToListAsync();
            return git;
        }

     
        

      async  Task IMember.Update(Member member)
        {
            var mo = context.members.Update(member);
            await context.SaveChangesAsync();
        }
    }
}
