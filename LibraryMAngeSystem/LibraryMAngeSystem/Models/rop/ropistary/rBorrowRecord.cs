using LibraryMAngeSystem.Models.rop.internalinterface;
using LibraryMAngeSystem.Models.viewmodel;
using Microsoft.EntityFrameworkCore;

namespace LibraryMAngeSystem.Models.rop.ropistary
{
    public class rBorrowRecord : IBorrowRecord
    {
        private readonly appdbcontext context;
        public rBorrowRecord(appdbcontext appdbcontext)
        {
            context = appdbcontext;
            
        }
        async Task IBorrowRecord.Create(BorrowRecordviewModel model)
        {
            BorrowRecord borrow = new BorrowRecord()
            {
        
                Booid = model.Booid,
                MemID = model.MemID,
                ReturnDate = model.ReturnDate,
                Returned=model.Returned,
                BorrowRecor=model.BorrowRecor,
            };
            await  context.borrowRecords.AddAsync(borrow);
            await context.SaveChangesAsync();

        }

        async Task IBorrowRecord.Delete(BorrowRecord record)
        {
            context.borrowRecords.Remove(record);
            await context.SaveChangesAsync();
        }

        async Task<BorrowRecord> IBorrowRecord.Details(int id)
        {
            var search= await context.borrowRecords.Include(i => i.Member).Include(o => o.Book).FirstOrDefaultAsync(i=>i.BorrowId==id);
            return search;
        }

        async Task<ICollection<BorrowRecord>> IBorrowRecord.GetAll()
        {
            var bu = await context.borrowRecords.Include(i=>i.Member).Include(o=>o.Book).ToListAsync();   
            return bu;
        }

    
        
      async  Task<BorrowRecord> IBorrowRecord.update(BorrowRecordviewModel model)
        {
            var mo= new BorrowRecord();
            mo.BorrowId = model.Id;
            mo.Booid = model.Booid;
            mo.MemID = model.MemID;
            mo.ReturnDate = model.ReturnDate;
            mo.Returned = model.Returned;
            mo.BorrowRecor = model.BorrowRecor;
           
            context.borrowRecords.Update(mo);
            await context.SaveChangesAsync();
            return mo;
         
        }
    }
}
