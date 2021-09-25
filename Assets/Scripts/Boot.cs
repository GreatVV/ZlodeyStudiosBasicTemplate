using System.Collections;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Zlodey
{
    class Boot : MonoBehaviour
    {
        public StaticData StaticData;
        IEnumerator Start()
        {
            Service<StaticData>.Set(StaticData);
           
            GameInitialization.FullInit();
            yield return null;
            Levels.LoadCurrent();
        }
    }
}