using Buildings.Behaviours;
using Controllers.Gameplay.GameplayModes;
using UnityEngine;

namespace Buildings
{
    /// FIXME: Переделать в интерфейс?
    /** Базовый, элементарный класс, определяющий абстракцию здания. Костыль.
        Нужен для деформализации при десериализации объекта **/
    public abstract class SuperBuilding : MonoBehaviour
    {
        public BuildingBehaviour gameplayBehaviour { get; private set; }
        public abstract string SerializeProperties();
        public abstract void DeserializeProperties(string json);

        public void SetGameplayMode<GM>() where GM : BuildingBehaviour 
        {
            if (this.gameplayBehaviour != null) 
                throw new System.Exception();
            
            gameplayBehaviour = gameObject.AddComponent<GM>();
        }
    }
}
