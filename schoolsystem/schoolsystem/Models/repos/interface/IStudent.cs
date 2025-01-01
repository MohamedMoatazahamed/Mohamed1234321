namespace schoolsystem.Models.repos.internalinterface
{
    public interface IStudent
    {
        public Task<ICollection<Student>> Getall();
        public Task Creat(Student student);
        public Task Delete(Student student);
        public Task<Student> Details(int id);
        public Task<Student> Update(Student student,int id);
      
    }
}
