using ToDoList.Domain;
using ToDoList.Domain.Entities;
using ToDoList.Domain.ToDoListServiceResults;

namespace ToDoList.Application.ToDoList
{
    public interface IToDoList
    {
        Task<GetAllRecordsResult> GetAllRecordsAsync();

        Task<ResultBase> UpdateRecord(ToDoRecord record);

        Task<ResultBase> DeleteRecord(int recordId);
    }
}
