using Hospitall.Models.viewModel;

namespace Hospitall.Models.ropis.Iropis
{
    public interface Iappoin
    {
        Task<ICollection<Appointment>> Getall();
        Task create(appoviewModel  model);
        Task delete(Appointment appointment);
        Task<Appointment> update(appoviewModel model);
        Task<Appointment> Details(int Id);


    }
}
