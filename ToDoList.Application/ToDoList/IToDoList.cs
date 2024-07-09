using ToDoList.Domain;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enums;
using ToDoList.Domain.Forms;
using ToDoList.Domain.Results;

namespace ToDoList.Application.ToDoList
{
    public interface IToDoList
    {
        Task<GetRecordsResult> GetAllRecordsAsync();

        Task<GetRecordsResult> GetRecordsWithFilterAsync(DateTime? startDate, DateTime? endDate, ToDoType toDoType = ToDoType.All);

        Task<ResultBase> UpdateRecord(ToDoRecord record);

        Task<ResultBase> DeleteRecord(int recordId);

        Task<ResultBase> CreateRecordAsync(ToDoDetailsFormModel model);
    }
}
