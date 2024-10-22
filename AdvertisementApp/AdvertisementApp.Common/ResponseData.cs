using AdvertisementApp.Common.Enums;

namespace AdvertisementApp.Common
{
    public class ResponseData<T> : Response, IResponseData<T> 
    {
        public T Data { get; set; }

        public List<CustomValidationError> ValidationErrors { get; set; }
        public ResponseData(ResponseType responseType, string message) : base(responseType, message)
        {

        }

        public ResponseData(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public ResponseData(T data, List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            ValidationErrors = errors;
            Data = data;
        }
    }
}
