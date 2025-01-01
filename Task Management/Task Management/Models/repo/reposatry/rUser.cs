using Microsoft.EntityFrameworkCore;
using Task_Management.Models.repo.internalinterface;

namespace Task_Management.Models.repo.reposatry
{
    public class rUser : IUser
    {
        private readonly appdbcontext _context;
        public rUser(appdbcontext appdbcontext)
        {
            _context = appdbcontext;
            
        }
      
        

       async Task IUser.Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); ;
        }

        async Task IUser.Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
          

        }

        async Task<User> IUser.Details(int id)
        {
           var mo= await _context.Users.FindAsync(id);
            return mo;
        }

        async Task<ICollection<User>> IUser.GetAll()
        {
           var git=await _context.Users.ToListAsync();
            return git;
        }

        async Task IUser.Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
           
         
        }

     
    }
}
