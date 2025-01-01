using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management.Models.viewModel
{
    public class viewModelTask
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public int AssignedUserId { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<User> users { get; set; }
    }
}
