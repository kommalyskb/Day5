using System;
using System.Collections.Generic;
using System.Text;

namespace Day5.Shared.Entities
{
    public class DefaultResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
    }
}
