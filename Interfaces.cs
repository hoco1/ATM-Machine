namespace BankAccount.AccountInterface
{
    public interface IAccount<T>
    {   
        T balance { get; set; }
        T cardNumber { get; set; }
        void Withdraw(T amount);
        void Display();
    }
}

