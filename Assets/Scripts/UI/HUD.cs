using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI jumpCountText;
        [SerializeField] TextMeshProUGUI shotDownObjectsText;
        [SerializeField] TextMeshProUGUI gameTimeText;
        [Header("Resources")]
        [SerializeField] Player.PlayerData playerData;

        private const float MAX_TIMER = 0.1f;
        private float _timer = 0;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > MAX_TIMER)
            {
                UpdateStats();
                _timer = 0;
            }
        }

        private void UpdateStats()
        {
            jumpCountText.text = playerData.jumpCount.ToString();
            shotDownObjectsText.text = playerData.shotDownObjects.ToString();

            TimeSpan time = TimeSpan.FromSeconds(Time.realtimeSinceStartup);
            gameTimeText.text = time.ToString(@"hh\:mm\:ss");
        }
    }
}
