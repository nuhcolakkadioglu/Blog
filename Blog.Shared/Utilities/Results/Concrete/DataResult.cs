using Blog.Shared.Utilities.Results.Abstract;
using Blog.Shared.Utilities.Results.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public T Data { get; }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }


        public DataResult(ResultStatus resultStatus,T data)
        {
            this.Data = data;
            this.ResultStatus = resultStatus;
        }

        public DataResult(ResultStatus resultStatus,string message, T data)
        {
            this.Data = data;
            this.Message = message;
            this.ResultStatus = resultStatus;
        }
        public DataResult(ResultStatus resultStatus, string message, T data,Exception exception)
        {
            this.Data = data;
            this.Message = message;
            this.ResultStatus = resultStatus;
            this.Exception = exception;
        }

    }
}
