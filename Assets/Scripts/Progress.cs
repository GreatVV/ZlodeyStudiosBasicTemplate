using UnityEngine;

namespace Zlodey
{
    static partial class Progress
    {
        public static int CurrentLevel
        {
            get => PlayerPrefs.GetInt("CurrentLevel", 0);
            set => PlayerPrefs.SetInt("CurrentLevel", value);
        }
    }
}