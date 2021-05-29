using UnityEngine;
namespace OpenRTS.Assets.Scripts.Dadabases
{
    public class DatabasesManager : MonoBehaviour {
        public bool TryGetDataBase<T>(out IDataBase dbase) where T : IDataBase {  
            int dbasesCount = transform.childCount;
            DatabaseBuildings database = null;
            for(int index = 0; index < dbasesCount; index++) {
                if (transform.GetChild(index).TryGetComponent<DatabaseBuildings>(out database)) {
                    break;
                }
            }

            dbase = database;
            return dbase != null;
        }
    }
}