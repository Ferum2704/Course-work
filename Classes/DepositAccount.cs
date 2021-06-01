
namespace LibraryWallet
{
    public class DepositAccount : Account
    {
        double interest = 0;
        int interestPeriod;
        public event AccountHandler ChargedInterest;
        public DepositAccount(string someName, int someId, decimal initialBalance):base(someName, someId, initialBalance)
        {
            interestPeriod = 0;
        }
        private void OnCharged(AccountEventArgs e)
        {
            ChargedInterest(this, e);
        }
        public void SetInterest(double someInterest)
        {
            interest = someInterest;
        }
        public override void AddMoney(decimal someSum)
        {
            base.AddMoney(someSum);
            interestPeriod += 15;
            if (interestPeriod % 30 == 0)
            {
                CalculateBalanceWithInterest();
            }
        }
        private void CalculateBalanceWithInterest()
        {
            decimal depositIncome = Balance * (decimal)interest;
            Balance += depositIncome;
            OnCharged(new AccountEventArgs($"\nThe {Name} charged interests in the amount of {depositIncome}!"));
        }
    }
}
