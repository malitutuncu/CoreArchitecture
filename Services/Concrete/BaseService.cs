using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseService
    {
        public IResult Success()
        {
            var result = new Result();
            return result.SuccesResult();
        }

        public IDataResult<T> Success<T>(T data)
        {
            var result = new DataResult<T>();
            return result.SuccesResult(data);
        }

        public IResult Error(string mesaj)
        {
            var result = new Result();
            return result.ErrorResult(mesaj);
        }
    }
}
