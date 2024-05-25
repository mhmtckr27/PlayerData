using System;
using PlayerData.Application;
using PlayerData.Domain;

namespace PlayerData.Infrastructure
{
    public class PlayerDataRepository : IPlayerDataRepository
    {
        private readonly Domain.PlayerData _playerData;
        private readonly IConsumableDataRepository _consumableDataRepository;
        
        public event Action<Domain.PlayerData> OnChanged;
        
        public PlayerDataRepository()
        {
            _playerData = new Domain.PlayerData();
            _consumableDataRepository = new ConsumableDataRepository(_playerData.ConsumableData);
            _consumableDataRepository.OnChanged += ((_, _) => OnChanged?.Invoke(_playerData));
        }
        
        public Domain.PlayerData GetPlayerData()
        {
            return _playerData;
        }

        public IConsumableDataRepository GetConsumableDataRepository()
        {
            return _consumableDataRepository;
        }

        public override string ToString()
        {
            return _playerData.ToString();
        }
    }
}