using Task_Management.Models.viewModel;

namespace Task_Management.Models.repo.internalinterface
{
    public interface ITask
    {
        public Task<ICollection<Task1>> GetAll();
        public Task Create(viewModelTask modelTask);
        public Task<Task1> Update(viewModelTask modelTask);
        public Task Delete(Task1 task);
        public Task<Task1> Details(int id);
      
    }
}
