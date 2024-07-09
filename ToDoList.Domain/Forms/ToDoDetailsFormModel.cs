using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Forms
{
    public class ToDoDetailsFormModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime? DueDate { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
