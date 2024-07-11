using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Forms;
using ToDoList.Domain.Results;
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

        public async Task<GetRecordsResult> GetAllRecordsAsync()
        {
            try
            {
                var records = await _context.ToDoRecords
                    .Where(record => !record.IsDeleted)
                    .OrderBy(record => record.FinishedAt != null ? 1 : 0)
                    .ThenBy(record => record.DueDate == null ? 1 : 0)
                    .ThenBy(record => record.DueDate)
                    .ToListAsync();

                return new GetRecordsResult(records);
            }
            catch (Exception ex) {
                return new GetRecordsResult(ex.Message);
            }
        }

        public async Task<GetRecordsResult> GetRecordsWithFilterAsync(DateTime? startDate, DateTime? endDate, ToDoType toDoType = ToDoType.All)
        {
            try
            {
                // Filter records in database because SQLite is cheap
                var query = _context.ToDoRecords.Where(record => !record.IsDeleted).AsQueryable();

                if (toDoType == ToDoType.Completed)
                {
                    query = query.Where(t => t.State == ToDoState.Finished);
                }

                if (toDoType == ToDoType.Uncomplete)
                {
                    query = query.Where(t => t.State == ToDoState.Created);
                }

                if (startDate.HasValue)
                {
                    query = query.Where(t => t.CreatedOn >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(t => t.CreatedOn <= endDate.Value);
                }

                var records = await query
                    .Where(record => !record.IsDeleted)
                    .OrderBy(record => record.FinishedAt != null ? 1 : 0)
                    .ThenBy(record => record.DueDate == null ? 1 : 0)
                    .ThenBy(record => record.DueDate)
                    .ToListAsync();

                return new GetRecordsResult(records);
            }
            catch (Exception ex)
            {
                return new GetRecordsResult(ex.Message);
            }
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
                    // Logical delete
                    existRecord.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }

                return new ResultBase();
            }
            catch (Exception ex)
            {
                return new ResultBase(ex.Message);
            }
        }

        public async Task<ResultBase> CreateRecordAsync(ToDoDetailsFormModel model)
        {
            try
            {
                var record = new ToDoRecord
                {
                    Title = model.Title,
                    DueDate = model.DueDate,
                    Description = model.Description,
                    CreatedOn = DateTime.Now,
                    State = ToDoState.Created
                };

                await _context.ToDoRecords.AddAsync(record);

                await _context.SaveChangesAsync();

                return new ResultBase();
            }
            catch (Exception ex)
            {
                return new ResultBase(ex.Message);
            }
        }
    }
}
