using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public DataResult()
        {
            Errors = new List<string>();
        }

        public Task<DataResult<T>> SuccesResultAsync()
        {
            Success = true;
            return Task.FromResult(this);
        }
        public IDataResult<T> SuccesResult(T data)
        {
            Errors = null;
            Success = true;
            Data = data;
            return this;
        }

        public Task<DataResult<T>> SuccesResultAsync(T data)
        {
            Errors = null;
            Success = true;
            Data = data;
            return Task.FromResult(this);
        }

        public DataResult<T> SuccesResult(T data, string mesaj)
        {
            Errors[0] = mesaj;
            Success = true;
            Data = data;
            return this;
        }

        public DataResult<T> ErrorResult(string mesaj)
        {
            Success = false;
            Errors[0] = mesaj;
            return this;
        }
    }
}
