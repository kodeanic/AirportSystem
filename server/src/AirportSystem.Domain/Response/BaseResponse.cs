using AirportSystem.Domain.Enums;

namespace AirportSystem.Domain.Response;

public class BaseResponse<T> : IBaseResponse <T>
{
    public string Description { get; set; }
    public StatusCode StatusCode { get; set; }
    public T Data { get; set; }
}

public interface IBaseResponse<T>
{
    public string Description { get; set; }
    public StatusCode StatusCode { get; set; }
    T Data { get; set; }
}
