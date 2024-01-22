using System;

namespace TatlTestTask.GUI.Main
{
    public class MainMenuModel
    {
        public event Action showLevelsMenu;

        private readonly MainMenuView _view;

        public MainMenuModel(MainMenuView view) => _view = view;

        public void ShowLevelsMenu() => showLevelsMenu?.Invoke();

        public void HideView() => _view.gameObject.SetActive(false);

        public void ShowView() => _view.gameObject.SetActive(true);
    }
}