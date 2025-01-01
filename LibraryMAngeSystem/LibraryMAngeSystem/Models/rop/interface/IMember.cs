namespace LibraryMAngeSystem.Models.rop.internalinterface
{
    public interface IMember
    {
        public Task<ICollection<Member>> GetAll();
        public Task Craete(Member member);
        public Task Delete(Member member);
        public  Task Update(Member member);
        public Task<Member> Details(int id);
    }
}
