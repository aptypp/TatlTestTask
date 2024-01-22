using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace TatlTestTask.Player
{
    public class PlayerModel
    {
        private bool _isDashing;
        private bool _isJumping;
        private float _speed;
        private Vector3 _position;
        private Quaternion _rotation;

        private readonly PlayerView _playerView;
        private readonly PlayerParameters _parameters;

        public PlayerModel(PlayerParameters parameters, PlayerView playerView)
        {
            _playerView = playerView;
            _parameters = parameters;

            _position = _playerView.transform.position;
            _rotation = _playerView.transform.rotation;
        }

        public void Move()
        {
            _position += _playerView.transform.forward * (_speed * Time.deltaTime);
        }

        public void Rotate(Vector2 rotateDirection)
        {
            if (rotateDirection == Vector2.zero) return;

            _rotation = Quaternion.LookRotation(new Vector3(rotateDirection.x, 0, rotateDirection.y), Vector3.up);
        }

        public void CalculateSpeed(float joystickDistance)
        {
            _speed = Mathf.Lerp(_speed, GetTargetMoveSpeed(joystickDistance), _parameters.moveSpeed * Time.deltaTime);
        }

        public void ApplyChangesToViewSmoothed(float joystickDistance)
        {
            _playerView.transform.position = Vector3.Lerp(_playerView.transform.position, _position,
                _parameters.moveLerping * Time.deltaTime);
            _playerView.transform.rotation = Quaternion.Lerp(_playerView.transform.rotation, _rotation,
                _parameters.rotationLerping * Time.deltaTime);

            _playerView.SetMoveSpeedAnimation(Mathf.Lerp(_playerView.GetMoveSpeedAnimation(),
                GetAnimationSpeed(joystickDistance),
                _parameters.moveAnimationLerping * Time.deltaTime));
        }

        public void Jump()
        {
            if (_isDashing || _isJumping) return;

            CoroutineRunner.instance.StartCoroutine(ProceduralJump());
            _playerView.TriggerJumpAnimation();
        }

        public void Dash()
        {
            if (_isDashing || _isJumping) return;

            CoroutineRunner.instance.StartCoroutine(ProceduralDash());
            _playerView.TriggerDashAnimation();
        }

        private float GetAnimationSpeed(float joystickDistance)
        {
            return joystickDistance switch
            {
                <= 0.01f => 0,
                < 0.5f => 0.5f,
                _ => 1.0f
            };
        }

        private float GetTargetMoveSpeed(float joystickDistance)
        {
            return joystickDistance switch
            {
                <= 0.01f => 0,
                < 0.5f => _parameters.moveSpeed,
                _ => _parameters.runSpeed
            };
        }

        private IEnumerator ProceduralJump()
        {
            _isJumping = true;

            float speed = _parameters.jumpLerping;
            float jumpHeight = _parameters.jumpHeight;
            float jumpLength = _parameters.jumpLength;

            Vector3 startPoint = _playerView.transform.position;
            Vector3 endPoint = startPoint + _playerView.transform.forward * jumpLength;
            Vector3 maximumPoint = startPoint + _playerView.transform.forward * (jumpLength * 0.5f) +
                                   Vector3.up * jumpHeight;

            for (float progress = 0; progress < 1.0f; progress += speed * Time.deltaTime)
            {
                _position = Vector3.Lerp(startPoint, maximumPoint, progress);
                yield return null;
            }

            for (float progress = 0; progress < 1.0f; progress += speed * Time.deltaTime)
            {
                _position = Vector3.Lerp(maximumPoint, endPoint, progress);
                yield return null;
            }

            _position.y = 0;

            _isJumping = false;
        }

        private IEnumerator ProceduralDash()
        {
            _isDashing = true;

            float speed = _parameters.dashLerping;
            float dashLength = _parameters.dashLength;

            Vector3 startPoint = _playerView.transform.position;
            Vector3 endPoint = startPoint + _playerView.transform.forward * dashLength;

            for (float progress = 0; progress < 1.0f; progress += speed * Time.deltaTime)
            {
                _position = Vector3.Lerp(startPoint, endPoint, progress);
                yield return null;
            }

            _isDashing = false;
        }
    }
}