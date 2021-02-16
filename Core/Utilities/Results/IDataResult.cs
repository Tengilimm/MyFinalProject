using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //zaten mesaj içeriyor tekrar yazmıyor. Ama sen sadece void değil bir de değer döndürüyorsun o yüzden. T türünden bir de datan olsun dedik.
    //inter face interface i implement ederse implemente edilenler de burada varmış gibi olur.
    public interface IDataResult<T> :IResult
    {
        T Data { get; }
    }
}
