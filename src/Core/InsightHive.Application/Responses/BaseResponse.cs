namespace InsightHive.Application.Responses
{
    public class BaseResponse<T> 
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T Result { get; set; }

    }
}
