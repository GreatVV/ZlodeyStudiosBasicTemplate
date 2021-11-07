using UnityEngine.UI;

namespace Zlodey
{
    public class WinScreen : Screen
    {
        public Button NextLevelButton;

        void Start()
        {
            NextLevelButton.onClick.AddListener(OnNextLevelClick);
        }

        private void OnNextLevelClick()
        {
            Levels.LoadCurrent();
        }
    }
}