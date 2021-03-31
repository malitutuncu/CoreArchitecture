﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>
    {
        T Data { get; set; }
        bool Success { get; set; }
        List<string> Errors { get; set; }
    }
}
