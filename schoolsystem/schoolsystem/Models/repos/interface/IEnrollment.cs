using schoolsystem.Models.viewmodel;

namespace schoolsystem.Models.repos.internalinterface
{
    public interface IEnrollment
    {
        public Task<ICollection<Enrollment>> GetAll();
        public Task Create(Enrollmentviewmodel model);
        public Task Delete(Enrollment enrollment);
        public Task<Enrollment> Update(Enrollmentviewmodel model);
        public Task<Enrollment> Details(int id);
    }
}
