namespace schoolsystem.Models.repos.internalinterface
{
    public interface Iteather
    {
        public Task<ICollection<Teacher>> Getall();
        public Task  Create(Teacher teacher);
        public Task<Teacher> Update(Teacher teacher,int id);
        public Task Delete(Teacher teacher);
        public Task<Teacher> Detals(int id);

    }
}
