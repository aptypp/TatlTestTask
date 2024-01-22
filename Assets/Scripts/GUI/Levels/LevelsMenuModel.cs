using System;
using UnityEngine.SceneManagement;

namespace TatlTestTask.GUI.Levels
{
    public class LevelsMenuModel
    {
        public event Action showMainMenu;

        private readonly LevelsMenuView _view;

        public LevelsMenuModel(LevelsMenuView view) => _view = view;

        public void ShowMainMenu() => showMainMenu?.Invoke();

        public void HideView() => _view.gameObject.SetActive(false);

        public void ShowView() => _view.gameObject.SetActive(true);

        public void PlayLevel() => SceneManager.LoadScene(1);
    }
}