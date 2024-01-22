using UnityEngine;
using UnityEngine.UI;

namespace TatlTestTask.GUI.Levels
{
    public class LevelsMenuView : MonoBehaviour
    {
        [field: SerializeField]
        public Button hideLevelsMenu;

        [field: SerializeField]
        public Button[] playLevelButtons;
    }
}