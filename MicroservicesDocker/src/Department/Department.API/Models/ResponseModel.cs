namespace Department.API.Models
{
    public class ResponseModel
    {
        public string Message { get; set; } = "";
        public int StatusCode { get; set; }
        public bool isSuccess { get; set; } = false;
    }
}
