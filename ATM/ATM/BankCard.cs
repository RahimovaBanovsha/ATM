namespace ATM;
public class BankCard
{
    public string BankName { get; set; }
    public string FullName { get; set; }
    public string PAN { get; set; }
    public string PIN { get; set; }
    public string CVC { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Balance { get; set; }
    public BankCard(string bankName, string fullName, string pan, string pin, string cvc, DateTime expireDate, decimal balance)
    {
        BankName = bankName;
        FullName = fullName;
        PAN = pan;
        PIN = pin;
        CVC = cvc;
        ExpireDate = expireDate;
        Balance = balance;
    }
    public bool IsValidPin()
    {
        return (PIN.Length==4 && PIN.All(char.IsDigit));
    }
    public bool IsValidCVC()
    {
        return (CVC.Length==3 && CVC.All(char.IsDigit));
    }
    public bool IsValidPan()
    {
        return(PAN.Length==16 && PAN.All(char.IsDigit));
    }
    public string GetMaskedPAN()
    {
        return $"**** **** **** {PAN.Substring(PAN.Length - 4)}";
    }
    public override string ToString()
    {
        return $"{BankName} | {FullName} | Balance: {Balance:C}";
    }
    public bool IsExpired()
    {
        return DateTime.Now > ExpireDate;
    }
}
