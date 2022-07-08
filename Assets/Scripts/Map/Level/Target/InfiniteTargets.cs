using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class InfiniteTargets : MonoBehaviour, ITargetEffect
    {
        [Header("References")]
        [SerializeField] Transform spawnOrigin;
        [Header("Resources")]
        [SerializeField] GameObject shieldPrefab;
        [Header("Settings")]
        [SerializeField] int maxSpawnItems = 5;
        [SerializeField] float spawnRadius;
        [SerializeField] float spawnDelay;

        private List<Shield> _pooledShields = new List<Shield>();

        private bool _isActive = false;
        private float _timer;
        private int _activeShields;

        private void Update()
        {
            if (_isActive == false)
                return;

            if (_activeShields >= maxSpawnItems)
                return;

            if (_timer <= 0)
            {
                Spawn();
                _timer = spawnDelay;
            }

            _timer -= Time.deltaTime;
        }

        private void Spawn()
        {
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
            Shield shield;

            if (_pooledShields.Count < maxSpawnItems)
            {
                GameObject go = Instantiate(shieldPrefab, Vector3.zero, Quaternion.Euler(0, 0, 90), spawnOrigin);
                go.SetActive(false);
                shield = go.GetComponent<Shield>();
                shield.onKill += Release;

                _pooledShields.Add(shield);
            }
            
            shield = Get();
            if(shield != null)
            {
                shield.transform.localPosition = randomPosition;
                shield.gameObject.SetActive(true);
                _activeShields++;
            }
        }

        private Shield Get()
        {
            for (int i = 0; i < maxSpawnItems; i++)
            {
                if (_pooledShields[i].gameObject.activeInHierarchy == false)
                    return _pooledShields[i];
            }
            return null;
        }

        private void Release() => _activeShields--;

        public void Play() => _isActive = true;
        public void Stop() => _isActive = false;
    }
}
