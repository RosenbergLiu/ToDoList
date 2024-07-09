using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.ToDoListServiceResults
{
    public class GetAllRecordsResult : ResultBase
    {
        public List<ToDoRecord> Records { get; set; } = [];
    }
}
