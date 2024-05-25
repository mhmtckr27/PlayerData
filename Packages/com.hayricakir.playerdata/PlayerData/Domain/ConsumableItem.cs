namespace PlayerData.Domain
{
    public sealed class ConsumableItem
    {
        public string Name { get; private set; }
        public long Amount { get; private set; }

        public ConsumableItem(string name, long amount)
        {
            Name = name;
            Amount = amount;
        }
        
        public void Add(long toAdd)
        {
            Amount += toAdd;
        }

        public void Remove(long toRemove)
        {
            var newAmount = Amount - toRemove;

            Amount = newAmount < 0 ? 0 : newAmount;
        }
        
        public ConsumableItem Copy()
        {
            return new ConsumableItem(Name, Amount);
        }

        public override string ToString()
        {
            return $"{Name}\t\t{Amount}";
        }
    }
}