using System.IO;
using System.Collections.Generic;
using System;
using LibraryWallet;

namespace CourseWork
{
    static class FileOperations
    {
        const string fileBalancesName = @"C:\Bogdan\CourseWork\Balances.txt";
        public static void ReadBalances(ref List<decimal> accountBalances, ref List<string> accountNames)
        {
            foreach (string line in File.ReadAllLines(fileBalancesName))
            {
                if (line != "")
                {
                    string[] lineParts = line.Split(":");
                    accountNames.Add(lineParts[0]);
                    accountBalances.Add(Decimal.Parse(lineParts[1]));
                }
                else
                {
                    throw new FileEmptyException("File " + fileBalancesName + " is empty!");
                }
            }
        }
        public static List<IncomeItem> ReadIncomeItems(Account currentAccount)
        {
            string fileIncomesName = @"C:\Bogdan\CourseWork\" + currentAccount.Name + " Incomes.txt";
            List<IncomeItem> incomes = new List<IncomeItem>();
            foreach (string line in File.ReadAllLines(fileIncomesName))
            {
                if (line != "")
                {
                    string[] lineParts = line.Split(":");
                    incomes.Add(new IncomeItem(lineParts[0], Decimal.Parse(lineParts[1])));
                }
                else
                {
                    throw new FileEmptyException("File " + fileIncomesName + " is empty!");
                }
            }
            return incomes;
        }
        public static List<ExpenseItem> ReadExpensesItems(Account currentAccount)
        {
            string fileExpensesName = @"C:\Bogdan\CourseWork\" + currentAccount.Name + " Expenses.txt";
            List<ExpenseItem> expenses = new List<ExpenseItem>();
            foreach (string line in File.ReadAllLines(fileExpensesName))
            {
                if (line != "")
                {
                    string[] lineParts = line.Split(":");
                    expenses.Add(new ExpenseItem(lineParts[0], Decimal.Parse(lineParts[1])));
                }
                else
                {
                    throw new FileEmptyException("File " + fileExpensesName + " is empty!");
                }
            }
            return expenses;
        }
        public static void WriteIncomesItems(Account currentAccount)
        {
            string fileIncomesName = @"C:\Bogdan\CourseWork\" + currentAccount.Name + " Incomes.txt";
            StreamWriter outputFile = new StreamWriter(fileIncomesName);
            foreach (var item in currentAccount.Incomes)
            {
                outputFile.WriteLine(item.Name + ":" + item.Sum);
            }
            outputFile.Close();
        }
        public static void WriteExpensesItems(Account currentAccount)
        {
            string fileExpensesName = @"C:\Bogdan\CourseWork\" + currentAccount.Name + " Expenses.txt";
            StreamWriter outputFile = new StreamWriter(fileExpensesName);
            foreach (var item in currentAccount.GetExpenseItems())
            {
                outputFile.WriteLine(item.Name + ":" + item.Sum);
            }
            outputFile.Close();
        }
        public static void WriteBalances(Budget MyBudget)
        {
            StreamWriter outputFile = new StreamWriter(fileBalancesName);
            foreach (var account in MyBudget.GetAccounts())
            {
                outputFile.WriteLine(account.Name + ":" + account.Balance);
            }
            outputFile.Close();
        }
    }
}
