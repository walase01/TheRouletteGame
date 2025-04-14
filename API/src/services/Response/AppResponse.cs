using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.Response
{
    public class AppResponse
    {
        public bool Succeeded => Errors.Count == 0;
        public string Message { get; set; } = string.Empty;
        public List<Error> Errors { get; set; } = new();

        public static AppResponse<T> Success<T>(T result, string message = "") =>
            new AppResponse<T> { Result = result, Message = message };

        public static AppResponse<T> Fail<T>(string message, List<Error>? errors = null) =>
            new AppResponse<T> { Message = message, Errors = errors ?? new List<Error>() };
    }

    public class AppResponse<T> : AppResponse
    {
        public T? Result { get; set; }
    }

}
