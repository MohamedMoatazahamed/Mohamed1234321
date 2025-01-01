using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMAngeSystem.Models
{
    public class BorrowRecord
    {
        public int BorrowId { get; set; }
        public DateTime BorrowRecor { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Returned { get; set; }
        public int Booid { get; set; }
        [ForeignKey("Booid")]
        public Book Book { get; set; }
        public int MemID { get; set; }
        [ForeignKey("MemID")]
        public Member Member { get; set; }


    }
}
