namespace ATM;
public abstract class TransferFeePolicy
{
    public abstract decimal CalculateFee(decimal amount);
}

public class SameBankFeePolicy : TransferFeePolicy
{
    public override decimal CalculateFee(decimal amount) => 0;
}

public class LocalOtherBankFeePolicy : TransferFeePolicy
{
    public override decimal CalculateFee(decimal amount) => amount * 0.01M;
}

public class InternationalBankFeePolicy : TransferFeePolicy
{
    public override decimal CalculateFee(decimal amount) => amount * 0.03M;
}