using ATM;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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

Client[] clients = new[] { client1, client2, client3, client4, client5 };
List<(DateTime, string)> operationLogs = new List<(DateTime, string)>();

Client foundClient = null;

while (foundClient == null)
{
    Console.Write("Enter your PIN: ");
    string enteredPin = Console.ReadLine();
    foundClient = clients.FirstOrDefault(c => c.BankAccount.PIN == enteredPin);
    if (foundClient == null)
        Console.WriteLine("No card found with this PIN. Try again.\n");
}
// ATM Operations: 
bool isRunning = true;

while (isRunning)
{
    string[] mainOptions = {
        "Check Balance",
        "Withdraw Cash",
        "View Operation History",
        "Transfer to Another Card",
        "Exit"
    };

    int selectedOption = ShowMenu(mainOptions);

    switch (selectedOption)
    {
        case 0:
            Console.WriteLine($"Your balance: {foundClient.BankAccount.Balance} AZN");
            LogOperation("Checked balance.");
            Console.ReadKey();
            break;

        case 1:
            string[] cashOptions = {
                "10 AZN", "20 AZN", "50 AZN", "100 AZN", "Other (Enter manually)"
            };
            int cashChoice = ShowMenu(cashOptions);
            decimal withdrawAmount = cashChoice switch
            {
                0 => 10,
                1 => 20,
                2 => 50,
                3 => 100,
                4 => GetCustomAmount(),
                _ => 0
            };

            try
            {
                if (withdrawAmount > foundClient.BankAccount.Balance)
                    throw new InsufficientBalanceException("Insufficient balance for withdrawal.");

                foundClient.BankAccount.Balance -= withdrawAmount;
                Console.WriteLine($"Withdrawn: {withdrawAmount} AZN. New balance: {foundClient.BankAccount.Balance} AZN");
                LogOperation($"Withdrew {withdrawAmount} AZN");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
            break;

        case 2:
            string[] historyOptions = { "Last 1 day", "Last 5 days", "Last 10 days" };
            int historyChoice = ShowMenu(historyOptions);
            int days = historyChoice switch
            {
                0 => 1,
                1 => 5,
                2 => 10,
                _ => 0
            };

            var filteredLogs = operationLogs.Where(l => l.Item1 >= DateTime.Now.AddDays(-days)).ToList();
            Console.WriteLine($"\nOperations in last {days} day(s):");
            if (filteredLogs.Any())
            {
                foreach (var log in filteredLogs)
                    Console.WriteLine($"[{log.Item1}] - {log.Item2}");
            }
            else
            {
                Console.WriteLine("No operations found for selected period.");
            }
            Console.ReadKey();
            break;

        case 3:
            Console.Write("Enter receiver's PIN: ");
            string receiverPin = Console.ReadLine();
            Client receiverClient = clients.FirstOrDefault(c => c.BankAccount.PIN == receiverPin);

            if (receiverClient == null)
            {
                Console.WriteLine("No card found with this PIN.");
                Console.ReadKey();
                break;
            }

            Console.Write("Enter transfer amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount) || transferAmount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                Console.ReadKey();
                break;
            }

            try
            {
                TransferFeePolicy feePolicy = receiverClient.BankAccount.BankName == foundClient.BankAccount.BankName
                    ? new SameBankFeePolicy()
                    : (receiverClient.BankAccount.BankName.Contains("Foreign") ? new InternationalBankFeePolicy() : new LocalOtherBankFeePolicy());

                decimal fee = TransferService.TransferWithFee(foundClient.BankAccount, receiverClient.BankAccount, transferAmount, feePolicy);
                Console.WriteLine($"Transfer successful. Fee charged: {fee} AZN");
                LogOperation($"Transferred {transferAmount} AZN to {receiverClient.GetFullName()} (Fee: {fee} AZN)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Transfer failed: {ex.Message}");
            }
            Console.ReadKey();
            break;

        case 4:
            SaveHistoryToFile();
            Console.WriteLine("Thank you for using our ATM. Goodbye!");
            isRunning = false;
            break;
    }
}

// === Helper Methods ===
decimal GetCustomAmount()
{
    Console.Write("Enter custom amount: ");
    return decimal.TryParse(Console.ReadLine(), out decimal amount) ? amount : 0;
}

void LogOperation(string message)
{
    var entry = (DateTime.Now, message);
    operationLogs.Add(entry);
    File.AppendAllText("operation_history.txt", $"[{entry.Item1}] - {entry.Item2}\n");
}

void SaveHistoryToFile()
{
    File.WriteAllLines("operation_full_history.txt", operationLogs.Select(l => $"[{l.Item1}] - {l.Item2}"));
}

int ShowMenu(string[] options)
{
    int selected = 0;
    ConsoleKeyInfo key;
    Console.CursorVisible = false;

    while (true)
    {
        Console.Clear();
        Console.WriteLine($"{foundClient.Name} {foundClient.Surname}, welcome to ATM.\n");

        for (int i = 0; i < options.Length; i++)
        {
            if (i == selected)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"> {options[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }

        key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.UpArrow)
            selected = (selected == 0) ? options.Length - 1 : selected - 1;
        else if (key.Key == ConsoleKey.DownArrow)
            selected = (selected == options.Length - 1) ? 0 : selected + 1;
        else if (key.Key == ConsoleKey.Enter)
            break;
    }

    Console.CursorVisible = true;
    Console.Clear();
    return selected;
}

string GeneratePan(Random rand) => string.Concat(Enumerable.Range(0, 16).Select(_ => rand.Next(10).ToString()));
string GeneratePin(Random rand) => rand.Next(1000, 10000).ToString();
string GenerateCvc(Random rand) => rand.Next(100, 1000).ToString();