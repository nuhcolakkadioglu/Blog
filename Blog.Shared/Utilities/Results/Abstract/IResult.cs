using Blog.Shared.Utilities.Results.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        ResultStatus ResultStatus { get;}
        string Message { get; }
        Exception Exception { get; }
    }
}
