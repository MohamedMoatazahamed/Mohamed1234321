using Microsoft.EntityFrameworkCore;
using Task_Management.Models.repo.internalinterface;
using Task_Management.Models.viewModel;

namespace Task_Management.Models.repo.reposatry
{
    public class rTask : ITask
    {
        private readonly appdbcontext _context;
        public rTask(appdbcontext appdbcontext)
        {
            _context = appdbcontext;
            
        }
        async Task ITask.Create(viewModelTask modelTask)
        {
            Task1 task = new Task1()
            {

                Description = modelTask.Description,
                Status = modelTask.Status,
                AssignedUserId = modelTask.AssignedUserId,
                DueDate = modelTask.DueDate,
              

            };
            await _context.tasks.AddAsync(task);
            await _context.SaveChangesAsync();

           
        }

        async Task ITask.Delete(Task1 task)
        {
             _context.tasks.Remove(task);
            await _context.SaveChangesAsync();
          
        }

        async Task<Task1> ITask.Details(int id)
        {
           var ni=await _context.tasks.Include(u=>u.User).FirstOrDefaultAsync(i=>i.TaskId==id);
            return ni;
        }

     


     async   Task<ICollection<Task1>> ITask.GetAll()
        {
      
            var ni = await _context.tasks.Include(u => u.User).ToListAsync();
            return ni;
        }

     

        async Task<Task1> ITask.Update(viewModelTask modelTask)
        {
            Task1 task = new Task1()
            {
                Description = modelTask.Description,
                Status = modelTask.Status,
                AssignedUserId = modelTask.AssignedUserId,
                DueDate = modelTask.DueDate,
                TaskId = modelTask.TaskId

            };
            _context.tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
          
            throw new NotImplementedException();
        }
    }
}
