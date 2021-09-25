using System;

namespace Zlodey
{
    [Serializable]
    public class RuntimeData
    {
        public int Level;
        public GameState GameState;

        public float LevelStartedTime;
    }
}