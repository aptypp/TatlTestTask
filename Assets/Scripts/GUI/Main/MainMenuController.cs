using TatlTestTask.GUI.Levels;
using UnityEngine;

namespace TatlTestTask.GUI.Main
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private MainMenuView _view;

        private MainMenuModel _model;

        public void Initialize(LevelsMenuController levelsMenuController)
        {
            _model = new MainMenuModel(_view);

            _model.showLevelsMenu += levelsMenuController.ShowView;
            _model.showLevelsMenu += _model.HideView;

            _view.levelsButton.onClick.AddListener(_model.ShowLevelsMenu);
        }

        public void ShowView() => _model.ShowView();
    }
}