using UnityEngine;
using OpenRTS.Assets.Scripts.Dadabases;

public class GameplayModeBuilding : GameplayMode
{
    private IDataBase _DatabaseBuildings = null;
    void Start()
    {
        _IsAllNormal = CallDatabase<DatabaseBuildings>(out _DatabaseBuildings);
    }

    void Update()
    {
        
    }

    private void GetBuildingsDatabase() {
        
    }
}
