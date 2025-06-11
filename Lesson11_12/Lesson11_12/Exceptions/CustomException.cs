// Implicit Using*******************************************************************************
namespace Lesson11_12.Exceptions;

class CustomException:ApplicationException
{
    public int StatusCode { get; set; }
    public CustomException(string message) 
        : base(message) { }
    public CustomException(string message,int statusCode)
        :base(message)
    {
        StatusCode = statusCode;
    }
}
