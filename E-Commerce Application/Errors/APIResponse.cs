namespace E_Commerce_Application.Errors
{
    public class APIResponse
    {
        public APIResponse(int stat, string? message = null)
        {
            ErrorCode = stat; ErrorMessage = message ?? GetStatusMessage(stat);
        }

        private string? GetStatusMessage(int stat)
        {
            return stat switch
            {
                404 => "Not found",
                400 => "Bad request",
                300 => "Redirection",
                500 => "Internal server error",
                _ => null

            };
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

    }
}
