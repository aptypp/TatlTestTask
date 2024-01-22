using TatlTestTask.GUI.Main;
using UnityEngine;
using UnityEngine.UI;

namespace TatlTestTask.GUI.Levels
{
    public class LevelsMenuController : MonoBehaviour
    {
        [SerializeField]
        private LevelsMenuView _view;

        private LevelsMenuModel _model;

        public void Initialize(MainMenuController mainMenuController)
        {
            _model = new LevelsMenuModel(_view);

            _model.showMainMenu += mainMenuController.ShowView;
            _model.showMainMenu += _model.HideView;

            _view.hideLevelsMenu.onClick.AddListener(_model.ShowMainMenu);

            foreach (Button playButton in _view.playLevelButtons)
            {
                playButton.onClick.AddListener(_model.PlayLevel);
            }
        }


        public void ShowView() => _model.ShowView();
    }
}