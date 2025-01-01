using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMAngeSystem.Models.viewmodel
{
    public class BorrowRecordviewModel
    {
        public int Id { get; set; }
        public DateTime BorrowRecor { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Returned { get; set; }
        public bool IsAvailable { get; set; }
        public int Booid { get; set; }
        public int MemID { get; set; }
        public ICollection<Book>? books {  get; set; }
        public ICollection<Member>? members { get; set; }

     
    }
}
