using LibraryMAngeSystem.Models.rop.internalinterface;
using Microsoft.EntityFrameworkCore;

namespace LibraryMAngeSystem.Models.rop
{
    public class rBook : IBook
    {
        private readonly appdbcontext _context;
        public rBook(appdbcontext appdbcontext)
        { 
            _context = appdbcontext;


                    
        }
        async Task IBook.Create(Book book)
        {
         await _context.books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        async Task<Book> IBook.Deatails(int id)
        {
            var ser = await _context.books.FindAsync(id);
            return ser;
        }

        async Task IBook.Delete(Book book)
        {
         _context.books.Remove(book);
            await _context.SaveChangesAsync();
        }

        async Task<ICollection<Book>> IBook.GetAll()
        {
       var git=await _context.books.Where(x => x.IsAvailable == true).ToListAsync();
            return git;
        }

        async Task IBook.Update(Book book)
        {
            _context.books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
