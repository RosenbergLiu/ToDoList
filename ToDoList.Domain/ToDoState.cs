using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain
{
    public enum ToDoState
    {
        Unknown = 0,
        Created = 1,
        Finished = 2,
        Overdue = 3,
        Deleted = 4
    }
}
