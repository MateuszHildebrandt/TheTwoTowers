using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        private ILevel _currPlatformLevel;
        private ILevel _currTargetLevel;

        public void ChangePlatformLevel(ILevel newLevel)
        {
            ChangeLevel(ref _currPlatformLevel, newLevel);
            StopTargetLevel();
        }

        public void ChangeTargetLevel(ILevel newLevel) => ChangeLevel(ref _currTargetLevel, newLevel);

        private void ChangeLevel(ref ILevel currLevel, ILevel newLevel)
        {
            if (currLevel != null)
                currLevel.Stop();

            currLevel = newLevel;
            currLevel.Play();
        }

        private void StopTargetLevel()
        {
            if (_currTargetLevel != null)
                _currTargetLevel.Stop();
        }
    }
}