using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Model
{
    public class BaseResponse<T>
    {
        public bool Status { get; set; }
        public T Response { get; set; }
        public string ErrorMessage { get; set; }

        public BaseResponse<T> Success(T data)
        {
            return new BaseResponse<T> { Status = true, Response = data };
        }

        public BaseResponse<T> Fail(string message)
        {
            return new BaseResponse<T> { Status = false, ErrorMessage = message };
        }

        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}
