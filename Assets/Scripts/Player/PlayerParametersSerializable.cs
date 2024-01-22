using System;
using UnityEngine;

namespace TatlTestTask.Player
{
    [Serializable]
    public class PlayerParametersSerializable
    {
        [SerializeField]
        private float _runSpeed;

        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private float _moveLerping;

        [SerializeField]
        private float _rotationLerping;

        [SerializeField]
        private float _moveAnimationLerping;

        [SerializeField]
        private float _jumpHeight;

        [SerializeField]
        private float _jumpLength;

        [SerializeField]
        private float _jumpLerping;

        [SerializeField]
        private float _dashLength;

        [SerializeField]
        private float _dashLerping;

        public PlayerParameters GetRuntimeCopy()
        {
            PlayerParameters parameters = new();

            parameters.runSpeed = _runSpeed;
            parameters.moveSpeed = _moveSpeed;
            parameters.moveLerping = _moveLerping;
            parameters.rotationLerping = _rotationLerping;
            parameters.moveAnimationLerping = _moveAnimationLerping;
            parameters.jumpHeight = _jumpHeight;
            parameters.jumpLength = _jumpLength;
            parameters.jumpLerping = _jumpLerping;
            parameters.dashLength = _dashLength;
            parameters.dashLerping = _dashLerping;

            return parameters;
        }
    }
}