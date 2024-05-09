namespace Project.API.Models
{
    public class ResponseModel
    {
        public string Message { get; set; } = "";
        public int Status { get; set; }
        public bool isSuccess { get; set; } = false;
    }
}
