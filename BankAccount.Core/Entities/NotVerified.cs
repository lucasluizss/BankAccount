using System;
using BankAccount.Core.Interfaces;

namespace BankAccount.Core.Entities
{
    public class NotVerified : IAccountState
    {
        private Action onUnfreeze;

        public Action OnUnfreeze { get; private set; }

        public NotVerified(Action onUnfreeze) => this.OnUnfreeze = onUnfreeze;

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(this.OnUnfreeze);

        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}
