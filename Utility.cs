using BankAccount.AccountInterface;

namespace BankAccount.AccountClass
{
class Account<T> : IAccount<T>
{
    public T balance { get; set; }
    public T cardNumber { get; set; }
    public Account(T balance, T cardNumber)
    {
        this.balance = balance;
        this.cardNumber = cardNumber;
    }
    // Withdraw method
    public virtual void Withdraw(T amount)
    {
        if (Convert.ToDouble(amount) <= Convert.ToDouble(balance))
            balance = (T)Convert.ChangeType(Convert.ToDouble(balance) - Convert.ToDouble(amount), typeof(T));
        else
            Console.WriteLine("Insufficient funds");
    }

    // Display method
    public virtual void Display()
    {
        Console.WriteLine($"Card Number = {cardNumber} ,Balance = {balance:c}");
    }

    // Transfer method between two accounts
    public virtual void Transfer(T amount, Account<T> account)
    {
        if (Convert.ToDouble(amount) <= Convert.ToDouble(balance))
        {
            balance = (T)Convert.ChangeType(Convert.ToDouble(balance) - Convert.ToDouble(amount), typeof(T));
            account.balance = (T)Convert.ChangeType(Convert.ToDouble(account.balance) + Convert.ToDouble(amount), typeof(T));
        }
        else
            Console.WriteLine("Insufficient funds");
    }

    // BillPayment method
    public virtual void BillPayment(T amount, string billName)
    {
        if (Convert.ToDouble(amount) <= Convert.ToDouble(balance))
        {
            balance = (T)Convert.ChangeType(Convert.ToDouble(balance) - Convert.ToDouble(amount), typeof(T));
            Console.WriteLine($"Bill {billName} paid successfully, amount : {amount:c}");
        }
        else
            Console.WriteLine("Insufficient funds");
    }

}
}


