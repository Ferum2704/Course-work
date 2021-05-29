namespace Classes
{
    public abstract class Item
    {
        public Item(string someName)
        {
            name = someName;
        }
        public decimal sum { get; protected set; }
        public string name { get; protected set; }
        public abstract string ItemInformation();
        public abstract void AddSum(decimal someSum);
    }
}
