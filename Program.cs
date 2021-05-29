using System;
using System.Collections.Generic;
using Classes;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //creation and filling list of income items
            List<IncomeItem> Incomes = new List<IncomeItem>();
            Incomes.Add(new IncomeItem("Scholarship"));
            Incomes.Add(new IncomeItem("Business"));
            Incomes.Add(new IncomeItem("Social benefit"));
            Incomes.Add(new IncomeItem("Interest of deposit"));
            Incomes.Add(new IncomeItem("Part-time job salary"));
            Incomes.Add(new IncomeItem("Dividends"));
            Incomes.Add(new IncomeItem("Present"));
            Incomes.Add(new IncomeItem("Rent"));
            Incomes.Add(new IncomeItem("Other revenues"));

            //creation and filling list of expense items
            List<ExpenseItem> Expenses = new List<ExpenseItem>();
            Expenses.Add(new ExpenseItem("Taxes"));
            Expenses.Add(new ExpenseItem("Food"));
            Expenses.Add(new ExpenseItem("Clothing"));
            Expenses.Add(new ExpenseItem("Automobile"));
            Expenses.Add(new ExpenseItem("Insurance"));
            Expenses.Add(new ExpenseItem("Utilities"));
            Expenses.Add(new ExpenseItem("Debt Repayment"));
            Expenses.Add(new ExpenseItem("Health Care"));
            Expenses.Add(new ExpenseItem("Transport"));
            Expenses.Add(new ExpenseItem("Education"));
            Expenses.Add(new ExpenseItem("Entertainment and Recreation"));
            Expenses.Add(new ExpenseItem("Other expenditure"));

            Budget MyBudget = new Budget();

            //adding accounts to the budget
            MyBudget.CreateAccount("Privat Bank Card", 1);
            MyBudget.CreateAccount("Pumb Card", 2);
            MyBudget.CreateAccount("CreditAgricole Card", 3);

            //adding income and expense items to the each account
            int j = 0;
            foreach (var account in MyBudget.GetAccounts())
            {
                for (int i = j; i < Incomes.Count; i+=3)
                {
                    account.AddIncomeItem(Incomes[i]);
                }
                account.AddExpenseItems(Expenses);
                j++;
            }

            Console.Title = "My budget";
            ConsoleColor initialColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You have {0} accounts:\n", MyBudget.numberOfAccounts);

            Console.ForegroundColor = initialColor;
            Output.AllAccountsInfo(MyBudget);

            ConsoleKeyInfo answer = new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false);

            while (answer.KeyChar == 'y')//loop for constant operating with an accounts
            {
                try
                {
                    //choosing particular account for operating
                    Console.Write("\nChoose one of your account, input its number: ");
                    int checkAccountNum = Convert.ToInt32(Console.ReadLine());
                    Account currentAccount = MyBudget[checkAccountNum];

                    while (answer.KeyChar == 'y')//loop for constant operating with particular account
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nAvailable actions with accounts: \n");
                        Console.ForegroundColor = initialColor;
                        Console.WriteLine("1 - Top up an account");
                        Console.WriteLine("2 - Spend money from account");
                        Console.WriteLine("3 - View general information about account");
                        Console.WriteLine("4 - View detailed information about account");
                        Console.WriteLine("5 - View information about on particular item");
                        Console.WriteLine("6 - Transfer money to another account");
                        Console.WriteLine("7 - Information about all accounts");
                        Console.Write("\nInput number one of these operations: ");
                        int num = Convert.ToInt32(Console.ReadLine());//valuable for indicating on specific operation
                        switch (num)//selection of the specific operation to perform
                        {
                            case 1:
                                while (answer.KeyChar == 'y')//loop for constant operation performing
                                {
                                    answer = Operating.ToppingUp(currentAccount);//function call for adding money to account
                                }
                                break;
                            case 2:
                                while (answer.KeyChar == 'y')
                                {
                                    answer = Operating.Spending(currentAccount);//function call to withdraw money
                                }
                                break;
                            case 3:
                                Output.GetGeneralInformation(currentAccount);
                                break;
                            case 4:
                                Output.GetDetailedInformation(currentAccount);
                                break;
                            case 5:
                                Output.GetItemInformation(currentAccount);//function call to display information about specific item of account
                                break;
                            case 6:
                                while (answer.KeyChar == 'y')
                                {
                                    answer = Operating.Transferring(MyBudget, currentAccount);//function call to transfer money from account
                                }
                                break;
                            case 7:
                                Output.AllAccountsInfo(MyBudget);//function call to display information about all the accounts
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("It is invalid number for any operation");
                                Console.ForegroundColor = initialColor;
                                break;
                        }
                        Console.Write("\n\nDo you want to continue operating with selected account? If yes, press y: ");
                        answer = Console.ReadKey();
                    }
                }
                catch (IndexOutOfRangeException exp)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(exp.Message);
                    Console.ForegroundColor = initialColor;
                }
                catch(FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nIt is impossible to convert letters to numbers");
                    Console.ForegroundColor = initialColor;
                }
                Console.Write("\n\nDo you want to operate with one of the accounts again? If yes, press y: ");
                answer = Console.ReadKey();
            }
            Console.WriteLine();
            Output.AllAccountsInfo(MyBudget);
        }
    }
}
