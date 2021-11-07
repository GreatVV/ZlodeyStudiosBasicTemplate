using UnityEngine;
using UnityEngine.EventSystems;

namespace Zlodey
{
    public class UI : MonoBehaviour
    {
        public MenuScreen MenuScreen;
        public GameScreen GameScreen;
        public WinScreen WinScreen;

        public EventSystem EventSystem;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (!EventSystem.current && EventSystem.current != EventSystem)
            {
                EventSystem.gameObject.SetActive(false);
            }
            else
            {
                EventSystem.gameObject.SetActive(true);
            }
        }

        public void CloseAll()
        {
            MenuScreen.Show(false);
            GameScreen.Show(false);
            WinScreen.Show(false);
        }
    }
}