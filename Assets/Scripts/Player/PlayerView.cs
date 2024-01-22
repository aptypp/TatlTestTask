using UnityEngine;

namespace TatlTestTask.Player
{
    public class PlayerView : MonoBehaviour
    {
        [field: SerializeField]
        public Animator animator;

        private static readonly int _jumpHash = Animator.StringToHash("Jump");
        private static readonly int _dashHash = Animator.StringToHash("Dash");
        private static readonly int _moveSpeedHash = Animator.StringToHash("MoveSpeed");

        public void TriggerJumpAnimation() => animator.SetTrigger(_jumpHash);

        public void TriggerDashAnimation() => animator.SetTrigger(_dashHash);

        public void SetMoveSpeedAnimation(float speed) => animator.SetFloat(_moveSpeedHash, speed);
        
        public float GetMoveSpeedAnimation() => animator.GetFloat(_moveSpeedHash);
    }
}