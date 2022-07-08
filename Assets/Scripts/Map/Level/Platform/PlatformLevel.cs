using UnityEngine;
using UnityEngine.Playables;
using Zenject;

namespace Level
{
    [RequireComponent(typeof(PlayableDirector))]
    public class PlatformLevel : MonoBehaviour, ILevel
    {
        [Header("References")]
        [SerializeField] Transform content;

        private PlayableDirector _playableDirector;
        private LevelManager _levelManager;

        private IPlatformEffect[] _platformEffects;
        private IPlatformEffect[] PlatformEffects
        {
            get
            {
                if (_platformEffects == null)
                    _platformEffects = GetComponents<IPlatformEffect>();
                return _platformEffects;
            }
        }

        private void Awake()
        {
            _playableDirector = GetComponent<PlayableDirector>();
            content.gameObject.SetActive(false);
        }

        [Inject]
        private void Initializer(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        public void Setup() => _levelManager.ChangePlatformLevel(this);

        [ExposeMethod]
        public void Play()
        {          
            content.gameObject.SetActive(true);
            _playableDirector.Play();

            foreach (IPlatformEffect item in PlatformEffects)
                item.Play();
        }

        [ExposeMethod]
        public void Stop()
        {
            _playableDirector.Stop();
            content.gameObject.SetActive(false);

            foreach (IPlatformEffect item in PlatformEffects)
                item.Stop();
        }
    }
}
