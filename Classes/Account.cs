using System.Collections.Generic;

namespace Classes
{
    public class Account
    {
        List<ExpenseItem> expenses;
        public List<IncomeItem> incomes { get; private set; }
        IncomeItem selectedIncomeItem;
        ExpenseItem selectedExpenseItem;
        public Account(string someName, int someId)
        {
            expenses = new List<ExpenseItem>();
            incomes = new List<IncomeItem>();
            balance = 0m;
            name = someName;
            id = someId;
        }
        public string name { get; private set; }
        public int id { get; private set; }
        public decimal expenseSum { get; private set; }
        public decimal incomeSum { get; private set; }
        public decimal balance { get; private set; }
        public List<ExpenseItem> GetExpenseItems()
        {
            return expenses;
        }
        public IncomeItem GetSelectedIncomeItem()
        {
            return selectedIncomeItem;
        }
        public ExpenseItem GetSelectedExpenseItem()
        {
            return selectedExpenseItem;
        }
        public void AddIncomeItem(IncomeItem item)
        {
            incomes.Add(item);
        }
        public void AddExpenseItems(List<ExpenseItem> items)
        {
            foreach (var item in items)
            {
                ExpenseItem copy = new ExpenseItem(item.name);
                expenses.Add(copy);
            }
        }
        public bool ChooseIncomeItem(int checkItemNum)
        {
            for (int i = 0; i < incomes.Count; i++)
            {
                if (i == checkItemNum)
                {
                    selectedIncomeItem = incomes[i];
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return "Name: " + name + "\n   Balanсe: " + balance;
        }
        public bool ChooseExpenseItem(int checkItemNum)
        {
            for (int i = 0; i < expenses.Count; i++)
            {
                if (i == checkItemNum)
                {
                    selectedExpenseItem = expenses[i];
                    return true;
                }
            }
            return false;
        }
        public void SpendMoney(decimal someSum)
        {
            if ((balance - someSum) >= 0)
            {
                balance -= someSum;
                expenseSum += someSum;
                selectedExpenseItem.AddSum(someSum);
            }
            else
            {
                throw new OperationPerformingException("\nYou don't have enough money on your account to spend such sum");
            }
        }
        public void AddMoney(decimal someSum)
        {
            balance += someSum;
            incomeSum += someSum;
            selectedIncomeItem.AddSum(someSum);
        }
        public void IncreaseTotalSum(decimal someSum)
        {
            balance += someSum;
        }
        public void DecreaseTotalSum(decimal someSum)
        {
            balance -= someSum;
        }
    }
}
