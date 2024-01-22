using UnityEngine;

namespace TatlTestTask
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        
        [SerializeField]
        private Vector3 _offset;
        
        private Transform _target;

        public void SetTarget(Transform target) => _target = target;

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _speed * Time.deltaTime);
        }
    }
}