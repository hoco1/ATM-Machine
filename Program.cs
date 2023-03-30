using BankAccount.AccountClass;
using BankAccount.Menu;

class Program
{
    static void Main(string[] args)
    {   
        List<Account<double>> accounts = new List<Account<double>>();
        // Create 10 accounts and add them to the list
        for (int i = 0; i < 10; i++)
        {
            Account<double> account = new Account<double>(1000000, 5234567891234567 + i);
            accounts.Add(account);
        }

        // dictionary to store bill numbers
        Dictionary<string, string> billNumbers = new Dictionary<string, string>();
        billNumbers.Add("1", "Electricity");
        billNumbers.Add("2", "Water");

        // check validity of card number
        bool isValidCardNumber(string cardNumber,string status="default")
        {   
            if (cardNumber.Length != 16){
                return false;
            }
            // check if all digits are numbers
            foreach (char c in cardNumber)
            {
                if (!Char.IsDigit(c))
                    return false;
            }

            // check if card number already exists
            foreach (Account<double> account in accounts)
            {
                if (account.cardNumber == Convert.ToDouble(cardNumber))
                {
                    if (status == "transfer"){
                        return true;
                    }else
                    {
                        return false;
                    }
                }
                       
            }

            return true;
        }

        Console.Clear(); // clear the screen

        Stack<double> cardNumberStack = new Stack<double>();

        for(int i=0;i<3;i++){
            
            Console.Write("Enter card number : ");
            string cardNumber = Console.ReadLine();
            if (isValidCardNumber(cardNumber)){
                double cardNumber2 = Convert.ToDouble(cardNumber);
                Account<double> account = new Account<double>(1000000, cardNumber2);
                cardNumberStack.Push(cardNumber2);
                accounts.Add(account);
                break;
            }else
            {
                Console.WriteLine("Invalid card number | Card number already exists | Card number is not 16 digits");
            }
        }

        if (cardNumberStack.Count == 0){
            Console.WriteLine("You have exceeded the number of attempts");
            return;
        }

        // Display menu till user chooses to exit
        while(true)
        {
            Console.WriteLine("Enter your choice : ");
            Console.WriteLine($"{(int)Menu.CheckBalance} - Check Balance (for testing)))");
            Console.WriteLine($"{(int)Menu.Withdraw} - Withdraw");
            Console.WriteLine($"{(int)Menu.Transfer} - Transfer");
            Console.WriteLine($"{(int)Menu.BillPayment} - Bill Payment");
            Console.WriteLine($"{(int)Menu.ShowAllAccounts} - Show All Accounts (for testing))");
            Console.WriteLine($"{(int)Menu.Exit} - Exit");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                // parse the choice to enum
                Menu option = (Menu)choice;
                
                // access the last card number
                double cardNumber = cardNumberStack.Peek();
                Account<double> currentAccount = null; 
            
                // find the account with the card number
                foreach (Account<double> account in accounts)
                {
                    if (account.cardNumber == cardNumber)
                    {
                        currentAccount = account;
                        break;
                    }
                }

                // switch case for menu options
                switch (option)
                {
                    case Menu.CheckBalance:
                        currentAccount.Display();
                        break;
                    case Menu.Withdraw:
                        Console.Write("Enter amount to withdraw : ");
                        double amount = double.Parse(Console.ReadLine());
                        currentAccount.Withdraw(amount);
                        currentAccount.Display();
                        break;

                    case Menu.Transfer:
                        Console.Write("Enter card number to transfer to : ");
                        string cardNumberToTransfer = Console.ReadLine();

                        if (!isValidCardNumber(cardNumberToTransfer,"transfer"))
                        {
                            Console.WriteLine("Invalid card number | does not exist in array | Card number is not 16 digits | Card number is the same as the source card number");
                            break;
                        }

                        Account<double> accountToTransfer = accounts.Find(account => account.cardNumber == Convert.ToDouble(cardNumberToTransfer));

                        if(accountToTransfer == null)
                        {
                            Console.WriteLine("Account not found");
                            break;
                        }else if (accountToTransfer.cardNumber == currentAccount.cardNumber)
                        {
                            Console.WriteLine("Cannot transfer to the same account");
                            break;
                        }

                        Console.Write("Enter amount to transfer : ");
                        double amountToTransfer = double.Parse(Console.ReadLine());

                        currentAccount.Transfer(amountToTransfer, accountToTransfer);
                        currentAccount.Display();
                        break;
                    case Menu.BillPayment:

                        // which bill to pay
                        Console.WriteLine("Which bill would you like to pay?");
                        Console.WriteLine("1. Electricity");
                        Console.WriteLine("2. Water");
                        string billNumber = Console.ReadLine();

                        // check if bill number is valid
                        if (!billNumbers.ContainsKey(billNumber))
                        {
                            Console.WriteLine("Invalid bill number");
                            break;
                        }

                        Console.Write("Enter amount to pay : ");
                        double amountToPay = double.Parse(Console.ReadLine());
                        currentAccount.BillPayment(amountToPay, billNumbers[billNumber]);
                        currentAccount.Display();
                        break;
                    case Menu.ShowAllAccounts:
                        foreach (Account<double> account in accounts)
                        {
                            account.Display();
                        }
                        break;
                    case Menu.Exit:
                        Console.WriteLine("Thank you for using the ATM!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();  
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    }
}