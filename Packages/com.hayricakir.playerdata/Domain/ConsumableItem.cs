using System;
using UnityEngine;

namespace PlayerData.Domain
{
    [Serializable]
    public sealed class ConsumableItem
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public long Amount { get; private set; }

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

        public void SetName(string newName)
        {
            Name = newName;
        }

        public void SetAmount(long newAmount)
        {
            Amount = newAmount;
        }

        public override string ToString()
        {
            return $"{Name}\t\t{Amount}";
        }
    }
}