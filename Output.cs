using System;
using Classes;

namespace CourseWork
{
    static class Output
    {
        public static void ShowListofIncomeItems(Account account)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nAvailable income items on {0}:", account.name);
            Console.ForegroundColor = ConsoleColor.Black;
            int i = 1;
            foreach (var item in account.incomes)
            {
                Console.WriteLine("{0}) {1};", i, item.name);
                i++;
            }
        }
        public static void ShowListofExpenseItems(Account account)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nAvailable expense items on {0}:", account.name);
            Console.ForegroundColor = ConsoleColor.Black;
            int i = 1;
            foreach (var item in account.GetExpenseItems())
            {
                Console.WriteLine("{0}) {1};", i, item.name);
                i++;
            }
        }
        public static void GetGeneralInformation(Account account)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nInformation about {0}:", account.name);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Current balance: {0}", account.balance);
            Console.WriteLine("Total incomes: {0}", account.incomeSum);
            Console.WriteLine("Total expenses: {0}", account.expenseSum);
        }
        public static void GetItemInformation(Account account)
        {
            Console.Write("Do you want to get information about income or expense item? Enter 'i' or 'e': ");
            
            ConsoleKeyInfo key = Console.ReadKey();//variable for denoting type if item
            ConsoleKeyInfo answer = new ConsoleKeyInfo('y', ConsoleKey.Y, false, false, false);

            int someItemNum;
            while (answer.KeyChar == 'y')
            {
                switch (key.KeyChar)
                {                 
                    case 'i':
                        ShowListofIncomeItems(account);
                        Console.Write("Choose one of income items: ");                      
                        someItemNum = Convert.ToInt32(Console.ReadLine());
                        if (account.ChooseIncomeItem(someItemNum - 1))
                        {
                            Console.WriteLine(account.GetSelectedIncomeItem());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no item for such number");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        break;
                    case 'e':
                        ShowListofExpenseItems(account);
                        Console.Write("Choose one of expense items: ");
                        someItemNum = Convert.ToInt32(Console.ReadLine());
                        if (account.ChooseExpenseItem(someItemNum - 1))
                        {
                            Console.WriteLine(account.GetSelectedExpenseItem());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("There is no item for such number");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        break;
                    default:
                        Console.WriteLine("There isn't such type of item");
                        break;
                }
                Console.Write("\nDo you want to get information about some item? If yes press y: ");
                answer = Console.ReadKey();
            }
        }
        public static void GetDetailedInformation(Account account)
        {
            GetGeneralInformation(account);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nReceived money from income items:");
            Console.ForegroundColor = ConsoleColor.Black;

            foreach (var item in account.incomes)
            {
                Console.WriteLine(item.ItemInformation());
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nSpent money on expense items:");
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (var item in account.GetExpenseItems())
            {
                Console.WriteLine(item.ItemInformation());
            }
        }
        public static void AllAccountsInfo(Budget MyBudget)
        {
            foreach (var account in MyBudget.GetAccounts())
            {
                Console.WriteLine("{0}. {1}", account.id, account);
                Console.WriteLine();
            }
        }
    }
}
