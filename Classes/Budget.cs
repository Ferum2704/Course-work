using System.Collections.Generic;
using System;

namespace Classes
{
    public class Budget
    {
        private List<Account> Accounts = new List<Account>();
        public int numberOfAccounts { get; private set; }
        public void CreateAccount(string name, int id)
        {
            Accounts.Add(new Account(name, id));
            numberOfAccounts++;
        }
        public List<Account> GetAccounts()
        {
            return Accounts;
        }
        public Account this[int numberOfAccount]
        {
            get
            {
                foreach (var account in Accounts)
                {
                    if (account.id == numberOfAccount)
                    {
                        return account;
                    }
                }
                throw new IndexOutOfRangeException("\nThere isn't account for choosen index");
            }
        }
        public void TransferMoney(decimal someSum, Account accountSender, Account accountRecipient)
        {
            if ((accountSender.balance - someSum)>=0)
            {
                accountSender.DecreaseTotalSum(someSum);
                accountRecipient.IncreaseTotalSum(someSum);
            }
            else
            {
                throw new OperationPerformingException("\nYou don't have enough money on your account to transfer such sum");
            }
        }
    }
}
