using TatlTestTask.GUI.Levels;
using TatlTestTask.GUI.Main;
using UnityEngine;

namespace TatlTestTask.GUI
{
    public class UIScene : MonoBehaviour
    {
        [SerializeField]
        private MainMenuController _mainMenuController;

        [SerializeField]
        private LevelsMenuController _levelsMenuController;

        private void Awake()
        {
            _mainMenuController.Initialize(_levelsMenuController);
            _levelsMenuController.Initialize(_mainMenuController);
        }
    }
}