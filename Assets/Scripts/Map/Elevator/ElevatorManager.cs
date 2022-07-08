using System.Collections;
using TMPro;
using UnityEngine;

namespace Elevator
{
    public class ElevatorManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshPro currLevelText;
        [Header("Settings")]
        [SerializeField] float speed = 5f;

        private Transform _target = null;
        private float _positionY;

        public void SetLevel(Transform target)
        {
            _positionY = transform.position.y;
            _target = target;

            if (transform.position.y < target.position.y)
                currLevelText.text = "^";
            else
                currLevelText.text = "v";
        }

        private void FixedUpdate()
        {
            if (_target == null)
                return;

            _positionY = Mathf.MoveTowards(_positionY, _target.position.y, Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x, _positionY, transform.position.z);

            if (transform.position.y == _target.position.y)
            {
                currLevelText.text = _target.parent.GetSiblingIndex().ToString();
                _target = null;
            }
        }
    }
}
