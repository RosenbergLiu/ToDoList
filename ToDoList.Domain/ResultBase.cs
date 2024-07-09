using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain
{
    public class ResultBase
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public ResultBase(string message) {
            IsSuccess = false;
            Message = message;
        }

        public ResultBase()
        {
            IsSuccess = true;
            Message = string.Empty;
        }
    }
}
