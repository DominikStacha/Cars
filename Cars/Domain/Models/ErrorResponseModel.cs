namespace Cars.Domain.Models
{
    public class ErrorResponseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string StackTrace { get; set; }
    }
}