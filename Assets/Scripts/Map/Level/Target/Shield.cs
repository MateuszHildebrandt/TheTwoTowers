using Game;
using Player;
using System;
using UnityEngine;

namespace Level
{
    public class Shield : MonoBehaviour, IKill
    {
        [SerializeField] PlayerData _playerData;
        public Action onKill;

        public void Kill()
        {
            _playerData.shotDownObjects++;
            gameObject.SetActive(false);
            onKill?.Invoke();
        }
    }
}
