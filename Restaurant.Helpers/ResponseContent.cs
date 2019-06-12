namespace Restaurant.Helpers
{
    public class ResponseContent
    {
        public object Object { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
