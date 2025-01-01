namespace LibraryMAngeSystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Phonenumber { get; set; }
        public ICollection<BorrowRecord> BorrowRecords { get; set; }
    }
}
