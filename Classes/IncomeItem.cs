
using System;

namespace Classes
{
    public class IncomeItem : Item
    {
        public IncomeItem(string someName):base(someName)
        {
            sum = 0;
        }

        public override string ItemInformation() { return name + ": " + sum; }
        public override string ToString()
        {

            return "You get " + sum + " from " + name;
        }
        public override void AddSum(decimal someSum)
        {
            sum += someSum;
        }
    }
}
