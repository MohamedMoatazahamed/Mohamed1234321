using LibraryMAngeSystem.Models.viewmodel;

namespace LibraryMAngeSystem.Models.rop.internalinterface
{
    public interface IBorrowRecord
    {
        public Task<ICollection<BorrowRecord>> GetAll();
        public Task Create(BorrowRecordviewModel model);
        public Task Delete(BorrowRecord record);
        public Task<BorrowRecord> update(BorrowRecordviewModel model);
        public Task<BorrowRecord> Details(int id);
    }
}
