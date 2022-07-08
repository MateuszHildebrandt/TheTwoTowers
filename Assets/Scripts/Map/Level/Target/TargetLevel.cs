using UnityEngine;
using UnityEngine.Playables;
using Zenject;

namespace Level
{
    public class TargetLevel : MonoBehaviour, ILevel
    {
        [Header("References")]
        [SerializeField] Transform content;
        [Header("Settings")]
        [SerializeField] bool isUsePlayableDirector;

        private LevelManager _levelManager;

        private PlayableDirector _playableDirector;
        private PlayableDirector MyPlayableDirector
        {
            get
            {
                if (_playableDirector == null)
                    _playableDirector = GetComponent<PlayableDirector>();
                return _playableDirector;
            }
        }

        private ITargetEffect[] _targetEffects;
        private ITargetEffect[] TargetEffects
        {
            get
            {
                if (_targetEffects == null)
                    _targetEffects = GetComponents<ITargetEffect>();
                return _targetEffects;
            }
        }

        private void Awake()
        {
            content.gameObject.SetActive(false);
        }

        [Inject]
        private void Initializer(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        public void Setup() =>_levelManager.ChangeTargetLevel(this);

        public void Play()
        {
            if (isUsePlayableDirector)
                MyPlayableDirector.Play();

            ResetShields();
            content.gameObject.SetActive(true);

            foreach (ITargetEffect item in TargetEffects)
                item.Play();
        }

        public void Stop()
        {
            if (isUsePlayableDirector)
                MyPlayableDirector.Stop();

            content.gameObject.SetActive(false);

            foreach (ITargetEffect item in TargetEffects)
                item.Stop();
        }

        private void ResetShields()
        {
            Shield[] shields = content.GetComponentsInChildren<Shield>(includeInactive: true);
            foreach (Shield item in shields)
                item.gameObject.SetActive(true);
        }
    }
}
