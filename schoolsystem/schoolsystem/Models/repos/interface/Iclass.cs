namespace schoolsystem.Models.repos.internalinterface
{
    public interface Iclass
    {
        public Task<ICollection<Class>> Getall();
    }
}
