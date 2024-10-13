namespace AdvertisementApp.Common
{
    public interface IResponseData<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidationError> ValidationErrors { get; set; }
    }
}
