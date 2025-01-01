using Microsoft.EntityFrameworkCore;
using schoolsystem.Models.repos.internalinterface;

namespace schoolsystem.Models.repos.rop
{
    public class rClass :Iclass
    {
        private readonly appdbcontext context;
        public rClass(appdbcontext appdbcontext)
        {
            this.context = appdbcontext;
            
        }

        async Task<ICollection<Class>> Iclass.Getall()
        {
            var mo = await context.Classs.ToListAsync();
            return mo;
        }
    }
}
