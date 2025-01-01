namespace Task_Management.Models.repo.internalinterface
{
    public interface IUser
    {
        public Task<ICollection<User>> GetAll();
        public Task Create(User user);
        public Task Update(User user);
        public Task Delete(User user);
        public Task<User> Details(int id);
    }
}
