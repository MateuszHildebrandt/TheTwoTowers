using Tools;
using UnityEngine;

namespace Level
{
    public class PlatformFade : MonoBehaviour, IPlatformEffect
    {
        [Header("Resources")]
        [SerializeField] Material platformMaterial;
        [Header("Settings")]
        [SerializeField] float platformVisibility = 4f;

        private bool _isActive;
        private Color _platformColor;
        private float _timer = 1;

        public void Awake()
        {
            _platformColor = platformMaterial.color;
            SetPlatformMaterialAlpha(1);
        }

        private void Update()
        {
            if (_isActive == false)
                return;

            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Toggle();
                _timer = platformVisibility;
            }
        }

        private void OnApplicationQuit()
        {
            _platformColor.a = 1;
            platformMaterial.color = _platformColor;
        }

        public void Play()
        {
            _isActive = true;
            _platformColor.a = 1;
        }

        public void Stop()
        {
            _isActive = false;
            _platformColor.a = 0;
        }

        private void Toggle()
        {
            StopAllCoroutines();

            float start = _platformColor.a;
            float end = 1 - start;

            StartCoroutine(Interpolation.Lerp(start, end, duration: 1, (value) => SetPlatformMaterialAlpha(value)));
        }

        private void SetPlatformMaterialAlpha(float value)
        {
            _platformColor.a = value;
            platformMaterial.color = _platformColor;
        }
    }
}
