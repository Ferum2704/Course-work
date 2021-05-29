using System;
using Classes;

namespace CourseWork
{
    static class Operating
    {
        public static ConsoleKeyInfo Transferring(Budget MyBudget, Account currentAccount)
        {
            Console.WriteLine("\nCurrent balance: {0}", currentAccount.balance);
            Console.Write("\nEnter the number of account to which you want to transfer money: ");
            try
            {
                int numAccountForRefill = Convert.ToInt32(Console.ReadLine());

                if (MyBudget[numAccountForRefill] != null)
                {
                    Console.Write("Input sum which you want to transfer: ");
                    decimal someSum = Convert.ToDecimal(Console.ReadLine());
                    someSum = Math.Round(someSum, 2);//rounding sum to permissible value
                    if (someSum >= 0)
                    {
                        MyBudget.TransferMoney(someSum, currentAccount, MyBudget[numAccountForRefill]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You entered incorrect sum for transferring");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It is impossible to convert letters to numbers");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            catch (IndexOutOfRangeException exp)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            catch (OperationPerformingException exp)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp);
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write("\nDo you want to transfer money again? If yes press y: ");
            ConsoleKeyInfo answer = Console.ReadKey();
            return answer;
        }

        public static ConsoleKeyInfo Spending(Account currentAccount)
        {
            Console.WriteLine("\nCurrent balance: {0}", currentAccount.balance);
            Output.ShowListofExpenseItems(currentAccount);
            Console.Write("\nChoose an expense item for spending, enter its number: ");
            try
            {
                int checkItemNum = Convert.ToInt32(Console.ReadLine());
                if (currentAccount.ChooseExpenseItem(checkItemNum - 1))
                {
                    Console.Write("Input some sum for spending: ");
                    decimal someSum = Convert.ToDecimal(Console.ReadLine());
                    someSum = Math.Round(someSum, 2);

                    if (someSum >= 0)
                    {
                        currentAccount.SpendMoney(someSum);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You entered incorrect sum for spending");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("There is no item for such number");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It is impossible to convert letters to numbers");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            catch (OperationPerformingException exp)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(exp);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write("\nDo you want to spend money from account again? If yes press y: ");
            ConsoleKeyInfo ans = Console.ReadKey();
            return ans;
        }
        public static ConsoleKeyInfo ToppingUp(Account currentAccount)
        {
            Output.ShowListofIncomeItems(currentAccount);
            Console.Write("\nChoose an income item for topping up, enter its number: ");

            try
            {
                int checkItemNum = Convert.ToInt32(Console.ReadLine());
                if (currentAccount.ChooseIncomeItem(checkItemNum - 1))
                {
                    Console.Write("Input some sum for topping up: ");
                    decimal someSum = Convert.ToDecimal(Console.ReadLine());
                    someSum = Math.Round(someSum, 2);

                    if (someSum >= 0)
                    {
                        currentAccount.AddMoney(someSum);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You entered incorrect sum for topping up");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("There is no item for such number");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("It is impossible to convert letters to numbers");
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write("\nDo you want to top up an account again? If yes press y: ");
            ConsoleKeyInfo ans = Console.ReadKey();
            return ans;
        }
    }
}
