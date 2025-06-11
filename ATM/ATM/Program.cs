using ATM;
using System;
using System.Linq;

Random rand = new Random();

BankCard card1 = new BankCard("Kapital Bank", "Elvin Huseynov", GeneratePan(rand), "1000", GenerateCvc(rand), DateTime.Now.AddYears(2), rand.Next(100, 5000));
BankCard card2 = new BankCard("PASHA Bank", "Narmin Aliyeva", GeneratePan(rand), GeneratePin(rand), GenerateCvc(rand), DateTime.Now.AddYears(4), rand.Next(100, 5000));
BankCard card3 = new BankCard("ABB", "Tural Ahmadov", GeneratePan(rand), GeneratePin(rand), GenerateCvc(rand), DateTime.Now.AddDays(105), rand.Next(100, 5000));
BankCard card4 = new BankCard("Yelo Bank", "Aynur Rustamova", GeneratePan(rand), GeneratePin(rand), GenerateCvc(rand), DateTime.Now.AddYears(1), rand.Next(100, 5000));
BankCard card5 = new BankCard("Bank Respublika", "Murad Zeynalov", GeneratePan(rand), GeneratePin(rand), GenerateCvc(rand), DateTime.Now.AddMonths(3), rand.Next(100, 5000));

Client client1 = new Client(Guid.NewGuid(), "Elvin", "Huseynov", 25, 1200, card1);
Client client2 = new Client(Guid.NewGuid(), "Nermin", "Aliyeva", 22, 950, card2);
Client client3 = new Client(Guid.NewGuid(), "Tural", "Ahmadov", 30, 1600, card3);
Client client4 = new Client(Guid.NewGuid(), "Aynur", "Rustamova", 28, 1800, card4);
Client client5 = new Client(Guid.NewGuid(), "Murad", "Zeynalov", 27, 1450, card5);

Client[] clients = new Client[] { client1, client2, client3, client4, client5 };

Client foundClient = null;
while (foundClient == null)
{
    Console.Write("Enter your PIN: ");
    string enteredPin = Console.ReadLine();

    foundClient = clients.FirstOrDefault(c => c.BankAccount.PIN == enteredPin);
    if (foundClient == null)
    {
        Console.WriteLine("PIN not found. Try again.\n");
    }
}

Console.Clear();
Console.WriteLine($"Welcome, {foundClient.Name} {foundClient.Surname}!");

bool isRunning = true;
while (isRunning)
{
    Console.WriteLine("\nSelect an option:");
    Console.WriteLine("1. Check Balance");
    Console.WriteLine("2. Withdraw Cash");
    Console.WriteLine("3. Transfer to Another Card");
    Console.WriteLine("0. Exit");
    Console.Write("Choice: ");

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.WriteLine($"Balance: {foundClient.BankAccount.Balance:C}");
            break;

        case "2":
            Console.Write("Enter amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
            {
                if (withdrawAmount > foundClient.BankAccount.Balance)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                {
                    foundClient.BankAccount.Balance -= withdrawAmount;
                    Console.WriteLine($"Withdrawn: {withdrawAmount:C}. New Balance: {foundClient.BankAccount.Balance:C}");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
            break;

        case "3":
            try
            {
                Console.Write("Enter receiver PIN: ");
                string receiverPin = Console.ReadLine();

                Client receiverClient = clients.FirstOrDefault(c => c.BankAccount.PIN == receiverPin);
                BankCard receiverCard = receiverClient?.BankAccount;

                Console.Write("Enter amount to transfer: ");
                decimal.TryParse(Console.ReadLine(), out decimal amount);

                BankCard senderCard = foundClient.BankAccount;

                TransferFeePolicy feePolicy = receiverCard.BankName == senderCard.BankName
                    ? new SameBankFeePolicy()
                    : (receiverCard.BankName.Contains("Foreign") ? new InternationalBankFeePolicy() : new LocalOtherBankFeePolicy());

                decimal fee = TransferService.TransferWithFee(senderCard, receiverCard, amount, feePolicy);
                Console.WriteLine($"Transfer successful! Fee charged: {fee:C}");
            }
            catch (InvalidTransferTargetException ex)
            {
                Console.WriteLine($"Transfer failed: {ex.Message}");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Transfer failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            break;

        case "0":
            Console.WriteLine("Exiting ATM... Goodbye!");
            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

static string GeneratePan(Random rand)
{
    string pan = "";
    for (int i = 0; i < 16; i++)
        pan += rand.Next(0, 10);
    return pan;
}

static string GeneratePin(Random rand) => rand.Next(1000, 10000).ToString();

static string GenerateCvc(Random rand) => rand.Next(100, 1000).ToString();
