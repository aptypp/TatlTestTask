using System;
using FormatGames.VirtualJoystick.Pro;
using UnityEngine;
using UnityEngine.UI;

namespace TatlTestTask.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Button _jumpButton;

        [SerializeField]
        private Button _dashButton;

        [SerializeField]
        private Joystick _joystick;

        [SerializeField]
        private PlayerBase _playerBase;

        [SerializeField]
        private TargetFollower _cameraFollower;

        private PlayerView _playerView;
        private PlayerModel _playerModel;

        private void Awake()
        {
            _playerView = Instantiate(_playerBase.playerViewPrefab);

            _cameraFollower.SetTarget(_playerView.transform);

            _playerModel = new PlayerModel(_playerBase.playerParameters.GetRuntimeCopy(), _playerView);
            
            _jumpButton.onClick.AddListener(_playerModel.Jump);
            _dashButton.onClick.AddListener(_playerModel.Dash);
        }

        private void Update()
        {
            float joystickDistance = _joystick.GetDistanceFromCenter();
            _playerModel.CalculateSpeed(joystickDistance);
            _playerModel.Rotate(_joystick.AXIS);
            _playerModel.Move();
            _playerModel.ApplyChangesToViewSmoothed(joystickDistance);
        }
    }
}