using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain.Entities
{
    public class ToDoRecord
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? FinishedAt { get; set; }

        public string Description { get; set; } = string.Empty;

        public ToDoState State { get; set; } = ToDoState.Created;

        public bool IsDeleted { get; set; } = false;
    }
}
