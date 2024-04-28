namespace E_Commerce_Application.Errors
{
    public class APIException:APIResponse
    {
        public APIException(int status, string message=null, string details=null):base(status, message)
        {
            this.details = details;
        }
        public string details { get; set; }

    }
}
