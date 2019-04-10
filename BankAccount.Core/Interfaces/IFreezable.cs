namespace BankAccount.Core.Interfaces
{
    public interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeze();
    }
}
