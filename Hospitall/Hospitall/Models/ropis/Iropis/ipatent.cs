namespace Hospitall.Models.ropis.Iropis

{
    public interface ipatent
    {
        Task<ICollection<Patient>> Getall();
        Task create(Patient patient);
        Task delete(Patient  patient);
        Task<Patient> Details(int Id);
        Task<Patient> update(Patient patient, int id);
    }
}
