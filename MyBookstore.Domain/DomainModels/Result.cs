using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookstore.Domain.DomainModels
{
    public class Result
    {
        public bool Succes { get; }
        public string Error { get; private set; } = string.Empty;

        protected Result(bool succes, string error)
        {
            Succes = succes;
            Error = error;
        }

        public static Result OK(string message)
        {
            return new Result(true, message);
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result Reset()
        {
            return new Result(false, string.Empty);
        }
    }
}
