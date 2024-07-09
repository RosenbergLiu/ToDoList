using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Results
{
    public class GetRecordsResult : ResultBase
    {
        public List<ToDoRecord> Records { get; set; } = [];

        public GetRecordsResult(string message) {
            IsSuccess = false;
            Message = message;
        }

        public GetRecordsResult(List<ToDoRecord> records) {
            IsSuccess = true;
            Records = records;
        }
    }
}
