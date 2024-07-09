using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;
using ToDoList.Domain.Entities;
using ToDoList.Domain.ToDoListServiceResults;
using ToDoList.Infrastructure;

namespace ToDoList.Application.ToDoList
{
    public class ToDoListService : IToDoList
    {
        private readonly AppDbContext _context;

        public ToDoListService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllRecordsResult> GetAllRecordsAsync()
        {
            var records = await _context.ToDoRecords
            .Where(record => !record.IsDeleted)
            .OrderBy(record => record.DueDate)
            .ToListAsync();

            if(records == null)
            {
                return new GetAllRecordsResult()
                {
                    IsSuccess = false,
                    Message = "Failed to get data",
                    Records = []
                };
            }

            return new GetAllRecordsResult { 
                IsSuccess = true,
                Records = records
            };
        }

        public async Task<ResultBase> UpdateRecord(ToDoRecord record)
        {
            var existRecord = await _context.ToDoRecords.FindAsync(record.Id);

            if (existRecord == null)
            {
                return new ResultBase("Record not exist");
            }

            _context.Entry(existRecord).CurrentValues.SetValues(record);

            await _context.SaveChangesAsync();

            return new ResultBase();
        }

        public async Task<ResultBase> DeleteRecord(int recordId)
        {
            try
            {
                var existRecord = await _context.ToDoRecords.FindAsync(recordId);

                if (existRecord != null)
                {
                    _context.ToDoRecords.Remove(existRecord);
                    await _context.SaveChangesAsync();
                }

                return new ResultBase();
            }
            catch (Exception ex)
            {
                return new ResultBase(ex.Message);
            }
        }

    }
}
