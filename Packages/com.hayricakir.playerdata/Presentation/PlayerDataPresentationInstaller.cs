using Zenject;

namespace PlayerData.Presentation
{
    public class PlayerDataPresentationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerDataController>().AsSingle().NonLazy();
        }
    }
}