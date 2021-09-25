using LeopotamGroup.Globals;
using UnityEngine;

namespace Zlodey
{
    static class GameInitialization
    {
        public static void FullInit()
        {
            InitializeUi();
        }

        public static UI.UI InitializeUi()
        {
            var configuration = Service<StaticData>.Get();
            var ui = Service<UI.UI>.Get();
            if (ui == null)
            {
                ui = Object.Instantiate(configuration.UI);
                Service<UI.UI>.Set(ui);
            }

            return ui;
        }
    }
}