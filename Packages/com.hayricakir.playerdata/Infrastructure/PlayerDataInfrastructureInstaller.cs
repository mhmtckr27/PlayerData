using PlayerData.Application;
using Zenject;

namespace PlayerData.Infrastructure
{
    public class PlayerDataInfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var playerDataRepository = Container.Instantiate<PlayerDataRepository>();
            
            Container
                .Bind<IConsumableDataRepository>()
                .FromInstance(playerDataRepository.GetConsumableDataRepository())
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<IPlayerDataRepository>()
                .FromInstance(playerDataRepository)
                .AsSingle()
                .NonLazy();
        }
    }
}