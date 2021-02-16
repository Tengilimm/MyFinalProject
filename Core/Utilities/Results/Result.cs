using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        //Çok önemli get; normalde sadece read only dir ve sadece consturctor ile set edilebilir.
        public Result(bool success, string message):this(success)//tek parametreli olana successi gönder demek. This li kısım.
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
