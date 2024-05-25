using System;
using PlayerData.Domain;

namespace PlayerData.Application
{
    public interface IConsumableDataRepository
    {
        void Add(ConsumableData toAdd);
        void Remove(ConsumableData toRemove);
        bool Contains(ConsumableData otherConsumableData);
        event Action<ConsumableData, ConsumableData> OnChanged;
        string ToString();
    }
}