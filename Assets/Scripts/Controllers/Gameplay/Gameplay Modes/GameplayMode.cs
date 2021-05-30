using UnityEngine;
using Dadabases;

namespace Controllers.Gameplay.GameplayModes 
{
    public abstract class GameplayMode : MonoBehaviour
    {
        [SerializeField]
        internal GameObject DatabasesManager;
        internal bool _IsAllNormal = true;
        public bool IsAllNormal => _IsAllNormal;

        internal bool CallDatabase<T>(out IDataBase dbase) where T : IDataBase {
            return DatabasesManager.GetComponent<DatabasesManager>().TryGetDataBase<T>(out dbase);
        }

    }
}