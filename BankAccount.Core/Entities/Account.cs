using System;
using BankAccount.Core.Interfaces;

namespace BankAccount.Core.Entities
{
    public class Account
    {
        protected decimal Balance { get; private set; }

        private IAccountState State { get; set; }

        //Change this istance (Active, Closed, Frozen, NotVerified) for entry types of bank account
        public Account(Action onUnfreeze) => this.State = new Active(onUnfreeze);

        public void Deposit(decimal amount) =>
            this.State = this.State.Deposit(() => {
                this.Balance += amount;
            });

        public void Withdraw(decimal amount) =>
            this.State = this.State.Withdraw(() => {
                this.Balance -= amount;
            });

        public void HolderVerified() => this.State = this.State.HolderVerified();

        public void Close() => this.State.Close();

        public decimal GetBalance() => this.Balance;
    }
}
