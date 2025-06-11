namespace ATM;
public static class TransferService
{
    public static decimal TransferWithFee(BankCard sender, BankCard receiver, decimal amount, TransferFeePolicy feePolicy)
    {
        if (receiver == null)
            throw new InvalidTransferTargetException("Receiver not found.");

        if (feePolicy == null)
            throw new ArgumentNullException(nameof(feePolicy), "Fee policy must not be null.");

        if (amount <= 0)
            throw new ArgumentException("Transfer amount must be greater than zero.");

        decimal fee = feePolicy.CalculateFee(amount);
        decimal total = amount + fee;

        if (total > sender.Balance)
            throw new InsufficientBalanceException("Insufficient funds for transfer including fee.");

        sender.Balance -= total;
        receiver.Balance += amount;

        return fee;
    }
}


