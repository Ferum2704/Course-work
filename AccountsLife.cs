using System;
using System.Collections.Generic;
using System.IO;
using LibraryWallet;
namespace CourseWork
{
    static class AccountsLife
    {
        static public void CreateAccounts(Budget MyBudget)
        {
            List<decimal> accountBalances = new List<decimal>();
            List<string> accountNames = new List<string>();
            try
            {
                FileOperations.ReadBalances(ref accountBalances, ref accountNames);

                //adding accounts to the budget
                for (int i = 0; i < accountNames.Count; i++)
                {
                    MyBudget.CreateAccount(accountNames[i], i + 1, accountBalances[i]);
                }

                MyBudget.Transferred += Handlers.TransferMoneyHandler;
                //adding income and expense items to the each account
                foreach (var account in MyBudget.GetAccounts())
                {
                    account.AddIncomeItems(FileOperations.ReadIncomeItems(account));
                    account.AddExpenseItems(FileOperations.ReadExpensesItems(account));
                    account.Spent += Handlers.SpendMoneyHandler;
                    account.Added += Handlers.AddMoneyHandler;
                    if (account is DepositAccount)
                    {
                        DepositAccount tempAccount = (DepositAccount)account;
                        tempAccount.SetInterest(0.1);
                        tempAccount.ChargedInterest += Handlers.ChargedInterestHandler;
                    }
                }
            }
            catch (FileNotFoundException exp)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch(FileEmptyException exp)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static public void FinishAccountsOperation(Budget MyBudget)
        {
            FileOperations.WriteBalances(MyBudget);
            foreach (var account in MyBudget.GetAccounts())
            {
                FileOperations.WriteExpensesItems(account);
                FileOperations.WriteIncomesItems(account);
            }
        }
    }
}
