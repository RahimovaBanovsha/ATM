namespace ATM;
public class InsufficientBalanceException : ApplicationException
{
    public InsufficientBalanceException(string message) : base(message) { }
}

public class InvalidTransferTargetException : ApplicationException
{
    public InvalidTransferTargetException(string message) : base(message) { }
}

public class InvalidPinException : ApplicationException
{
    public InvalidPinException(string message) : base(message) { }
}