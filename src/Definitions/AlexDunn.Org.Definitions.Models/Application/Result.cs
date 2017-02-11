using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDunn.Org.Definitions.Models.Application
{
    public class Result<T> where T : class
    {
        public T Data { get; set; }
        public string Error { get; set; }
        public ResultType Type { get; set; }

        public Result()
        {
        }
        public Result(T data)
        {
            Error = null;
            Data = data;
            Type = ResultType.Ok;
        }
        public Result(string error)
        {
            Error = error;
            Data = null;
            Type = ResultType.BadRequest;
        }
    }
}
