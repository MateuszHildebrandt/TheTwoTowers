using Game;
using UnityEngine;

namespace UI
{
    public class Crosshair : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] RectTransform up;
        [SerializeField] RectTransform down;
        [SerializeField] RectTransform left;
        [SerializeField] RectTransform right;
        [Header("Resources")]
        [SerializeField] Player.PlayerData playerData;
        [SerializeField] CrosshairData crosshairData;

        private float _defaultPosition;

        private void Start()
        {
            _defaultPosition = up.localPosition.y;
            SetCursorVisibility(false);
        }

        private void OnEnable() => SetCursorVisibility(true);

        private void OnDisable() => SetCursorVisibility(false);

        private void Update()
        {
            if (playerData.spread != 0)
            {
                up.localPosition = new Vector3(0, _defaultPosition + playerData.spread, 0);
                down.localPosition = new Vector3(0, -(_defaultPosition + playerData.spread), 0);
                left.localPosition = new Vector3(-(_defaultPosition + playerData.spread), 0, 0);
                right.localPosition = new Vector3(_defaultPosition + playerData.spread, 0, 0);
                
                playerData.ClampSpread(playerData.spread - 0.5f);
            }
        }

        private void SetCursorVisibility(bool value)
        {
            if (Cursor.visible != value)
            {
                Cursor.visible = value;
                Cursor.lockState = (value == true) ? CursorLockMode.Locked : CursorLockMode.None;
            }
        }
    }
}
