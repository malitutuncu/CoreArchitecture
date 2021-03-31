using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result()
        {
            Errors = new List<string>();
        }

        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        public Result ErrorResult(string mesaj)
        {
            Success = false;
            Errors[0] = mesaj;
            return this;
        }

        public Result ErrorResult(List<string> errors)
        {
            Success = false;
            Errors = errors;
            return this;
        }

        public Result SuccesResult()
        {
            Success = true;
            return this;
        }

        public Result SuccesResult(string mesaj)
        {
            Success = true;
            Errors[0] = mesaj;
            return this;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
