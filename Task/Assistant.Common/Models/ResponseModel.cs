using Assistant.Common.Enums;

namespace Assistant.Common.Models
{
    public class ResponseModel<T>
    {
        public OperationType OperationType { get; set; }

        public T Body { get; set; }

        public ErrorModel Error { get; set; }

        public ResponseModel(OperationType operationType, T body) : this(operationType)
        {
            Body = body;
            Error = new ErrorModel
            {
                ResultCode = GetResult(operationType, RequestResults.Ok)
            };
        }

        public ResponseModel(OperationType operationType, RequestResults resultCode, string message) : this(operationType)
        {
            Body = default;
            Error = new ErrorModel
            {
                ErrorMessage = message,
                ResultCode = resultCode
            };
        }

        public ResponseModel(OperationType operationType)
        {
            OperationType = operationType;
            Body = default;

            if (OperationType == OperationType.Delete)
            {
                Error = new ErrorModel
                {
                    ResultCode = RequestResults.Deleted
                };

            }

            if (operationType == OperationType.Get)
            {
                Error = new ErrorModel
                {
                    ResultCode = RequestResults.ValueNotFound
                };
            }
        }

        private RequestResults GetResult(OperationType operation, RequestResults result)
        {
            if (result == RequestResults.Ok)
            {
                switch (operation)
                {
                    case OperationType.Put:
                        return RequestResults.Updated;
                    case OperationType.Post:
                        return RequestResults.Created;
                    case OperationType.Get:
                        return RequestResults.Ok;
                    case OperationType.Delete:
                        return RequestResults.Deleted;
                    default:
                        return RequestResults.DatabaseError;
                }
            }

            return result;
        }
    }
}
