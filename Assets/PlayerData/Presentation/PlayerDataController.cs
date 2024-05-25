﻿using System;
using PlayerData.Application;
using PlayerData.Domain;

namespace PlayerData.Presentation
{
    public class PlayerDataController
    {
        private readonly Domain.PlayerData _playerData;
        private readonly IPlayerDataRepository _playerDataRepository;
        private readonly IConsumableDataRepository _consumableDataRepository;

        public event Action<Domain.PlayerData> OnChanged;

        public PlayerDataController(IPlayerDataRepository playerDataRepository)
        {
            _playerDataRepository = playerDataRepository;
            _playerData = _playerDataRepository.GetPlayerData();
            _consumableDataRepository = _playerDataRepository.GetConsumableDataRepository();
            _playerDataRepository.OnChanged += data => OnChanged?.Invoke(data);
        }

        public void AddConsumable(ConsumableData consumableData)
        {
            _consumableDataRepository.Add(consumableData);
        }

        public void RemoveConsumable(ConsumableData consumableData)
        {
            _consumableDataRepository.Remove(consumableData);
        }

        public bool HasConsumable(ConsumableData consumableData)
        {
            return _consumableDataRepository.Contains(consumableData);
        }

        public override string ToString()
        {
            return _playerDataRepository.ToString();
        }
    }
}