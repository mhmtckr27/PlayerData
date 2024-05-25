using System;
using PlayerData.Application;
using PlayerData.Domain;

namespace PlayerData.Infrastructure
{
    public class ConsumableDataRepository : IConsumableDataRepository
    {
        private readonly ConsumableData _consumableData;
        
        public event Action<ConsumableData, ConsumableData> OnChanged;
   
        public ConsumableDataRepository(ConsumableData consumableData)
        {
            _consumableData = consumableData;
        }
        
        public void Add(ConsumableData toAdd)
        {
            if(toAdd == null)
                return;

            var oldData = _consumableData.Copy();

            foreach (var consumableItemToAdd in toAdd.ConsumableItems)
            {
                var foundItem = _consumableData[consumableItemToAdd.Name];

                if (foundItem != null)
                    foundItem.Add(consumableItemToAdd.Amount);
                else
                    _consumableData.ConsumableItems.Add(new ConsumableItem(consumableItemToAdd.Name, consumableItemToAdd.Amount));
            }
            
            OnChanged?.Invoke(oldData, _consumableData);
        }

        public void Remove(ConsumableData toRemove)
        {
            var oldData = _consumableData.Copy();
            var isModified = false;

            foreach (var consumableItemToRemove in toRemove.ConsumableItems)
            {
                foreach (var consumableItem in _consumableData.ConsumableItems)
                {
                    if(!consumableItemToRemove.Name.Equals(consumableItem.Name))
                        continue;

                    if(!isModified)
                        isModified = true;
                    
                    consumableItem.Remove(consumableItemToRemove.Amount);
                    break;
                }
            }
            
            if(isModified)
                OnChanged?.Invoke(oldData, _consumableData);
        }

        public bool Contains(ConsumableData otherConsumableData)
        {
            foreach (var otherConsumableItem in otherConsumableData.ConsumableItems)
            {
                var foundItem = _consumableData[otherConsumableItem.Name];

                if (foundItem == null)
                    return false;

                if (foundItem.Amount < otherConsumableItem.Amount)
                    return false;
            }

            return true;
        }
        
        public override string ToString()
        {
            return _consumableData.ToString();
        }
    }
}