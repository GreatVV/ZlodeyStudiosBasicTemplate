using LeopotamGroup.Globals;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zlodey
{
    [CreateAssetMenu]
    public class Levels : ScriptableObject
    {
        [Scene] 
        public string[] Scenes;
        public int SkipLevels;

        public string this[int index]
        {
            get
            {
                return Scenes[index];
            }
        }
        
        public static void LoadCurrent()
        {
            var level = Progress.CurrentLevel;
            var staticData = Service<StaticData>.Get();
            
            var totalLevels = staticData.Levels.Scenes.Length;
            var index = level;
            if (level >= totalLevels)
            {
                index = level % totalLevels;
                index = staticData.Levels.SkipLevels + index % (totalLevels - staticData.Levels.SkipLevels);
            }
            
            var levelName = staticData.Levels.Scenes[index];
            SceneManager.LoadScene(levelName);
        }

        public static void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}