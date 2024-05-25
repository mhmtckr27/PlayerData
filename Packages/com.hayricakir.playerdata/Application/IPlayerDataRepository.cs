using System;

namespace PlayerData.Application
{
    public interface IPlayerDataRepository
    {
        PlayerData.Domain.PlayerData GetPlayerData();
        IConsumableDataRepository GetConsumableDataRepository();
        event Action<Domain.PlayerData> OnChanged;
        string ToString();
    }
}