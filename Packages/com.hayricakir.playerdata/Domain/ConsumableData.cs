using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerData.Domain
{
    public sealed class ConsumableData
    {
        public List<ConsumableItem> ConsumableItems { get; private set; }

        public ConsumableItem this[string consumableName] => FindConsumableItem(consumableName);

        public ConsumableData()
        {
            ConsumableItems = new List<ConsumableItem>();
        }

        private ConsumableItem FindConsumableItem(string consumableName)
        {
            foreach (var consumableItem in ConsumableItems)
            {
                if (consumableItem.Name == consumableName)
                    return consumableItem;
            }
            
            return null;
        }

        public ConsumableData Copy()
        {
            return new ConsumableData
            {
                ConsumableItems = ConsumableItems.Select(i => i.Copy()).ToList()
            };
        }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder("=====\tConsumableData\t\t=====\n");
            foreach (var consumableItem in ConsumableItems)
            {
                stringBuilder.AppendLine(consumableItem.ToString());
            }
            stringBuilder.Append("=====\tConsumableData\t\t=====");

            return stringBuilder.ToString();
        }
    }
}