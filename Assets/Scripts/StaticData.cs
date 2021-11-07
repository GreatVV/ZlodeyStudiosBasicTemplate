using UnityEngine;

namespace Zlodey
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Levels")]
        public Levels Levels;
        
        [Header("Required prefabs")]        
        public UI UI;

        [Header("Gameplay variable")] public float TimeToWinLevel = 1; //для примера - время в секундах после которого уровень выигрывается
    }
}