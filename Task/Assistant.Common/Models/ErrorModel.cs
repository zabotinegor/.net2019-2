using Assistant.Common.Enums;

namespace Assistant.Common.Models
{
    public class ErrorModel
    {
        public RequestResults ResultCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
