using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ExpenseItem : Item
    {
        public ExpenseItem(string someName): base(someName)
        {
            sum = 0;
        }
        public override string ItemInformation() { return name + ": " + sum; }
        public override string ToString()
        {
            return "You spent " + sum + " on " + name;
        }
        public override void AddSum(decimal someSum)
        {
            sum += someSum;
        }
    }
}
