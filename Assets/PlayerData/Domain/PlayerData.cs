using System.Text;

namespace PlayerData.Domain
{
    public class PlayerData
    {
        public ConsumableData ConsumableData { get; private set; }

        public PlayerData()
        {
            ConsumableData = new ConsumableData();
        }
        
        public PlayerData Copy()
        {
            return new PlayerData
            {
                ConsumableData = ConsumableData.Copy(),
            };
        }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder("=====\tPlayerData\t\t=====\n");

            stringBuilder.Append(ConsumableData);
            stringBuilder.Append("\n=====\tPlayerData\t\t=====\n");

            return stringBuilder.ToString();
        }
    }
}