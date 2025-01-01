namespace Hospitall.Models.ropis.Iropis
{
    public interface IDoctor
    {
        Task<ICollection<Doctor>> Getall();
        Task create(Doctor doctor);
        Task delete(Doctor doctor);
        Task<Doctor> update(int id,Doctor doctor);
        Task<Doctor> Details(int Id);
    }
}
