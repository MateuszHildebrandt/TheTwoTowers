using Elevator;
using Level;
using Player;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputActions>().AsSingle();
            Container.Bind<PlayerCamera>().FromComponentInHierarchy().AsSingle();

            Container.Bind<LevelManager>().FromComponentInParents().AsSingle();
            Container.Bind<ElevatorManager>().FromComponentInParents().AsSingle();
        }
    }
}
