using AirportSystem.Domain.Enums;

namespace AirportSystem.Domain.Response;

public class BaseResponse<T> : IBaseResponse <T>
{
    public StatusCode StatusCode { get; set; }
    public T Data { get; set; }
}

public interface IBaseResponse<T>
{
    public StatusCode StatusCode { get; set; }
    T Data { get; set; }
}
