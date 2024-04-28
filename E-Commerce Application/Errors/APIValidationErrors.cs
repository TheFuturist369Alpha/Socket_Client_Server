namespace E_Commerce_Application.Errors
{
    public class APIValidationErrors : APIResponse
    {
        public APIValidationErrors():base(400){

            }
        public IEnumerable<string> Errors { get; set; }
    }
}
