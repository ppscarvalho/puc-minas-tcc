namespace SGL.Util.Result
{
    public class ApiResult<T>
    {
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
