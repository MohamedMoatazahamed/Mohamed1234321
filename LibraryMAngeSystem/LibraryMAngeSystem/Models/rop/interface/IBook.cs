namespace LibraryMAngeSystem.Models.rop.internalinterface
{
    public interface IBook
    {
        public Task<ICollection<Book>> GetAll();
        public Task Create(Book book);
        public Task Delete(Book book);
        public Task Update(Book book);
        public Task<Book> Deatails(int id);
    }
}
