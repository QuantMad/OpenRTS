using Dadabases;

namespace Controllers.Gameplay.GameplayModes 
{
    public class GameplayModeBuilding : GameplayMode
    {
        private IDataBase _DatabaseBuildings = null;
        void Start()
        {
            //_IsAllNormal = CallDatabase<DatabaseBuildings>(out _DatabaseBuildings);
        }

        /*private bool CallDatabase<T>(out IDataBase databaseBuildings)
        {
            throw new NotImplementedException();
        }*/

        void Update()
        {
            
        }

        private void GetBuildingsDatabase() {
            
        }
    }
}