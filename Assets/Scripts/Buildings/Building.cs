using Buildings.Behaviours;
using UnityEngine;

namespace Buildings
{
    /** Обобщение здания. P определяет тип параметров здания в зависимости от типа здания. **/
    public abstract class Building<P> : SuperBuilding where P : BuildingProperties
    {
        // Параметры здания. Уникальны для каждого типа здания
        [SerializeField]
        internal P _properties;
        public P Properties => _properties;

        private BuildingBehaviour _buildingBehaviour;

        /* Производит десериализацию параметров из json */
        public override void DeserializeProperties(string json) 
        {
            // TODO: Валидация входящего json
            // TODO: Обработать возможные исключения невозможности 
            //       десериализации в данный тип параметров объекта
            _properties = JsonUtility.FromJson<P>(json);
        }

        public override string SerializeProperties()
        {
            return JsonUtility.ToJson(_properties);
        }

        public void SetBehaviour<B>() where B : BuildingBehaviour 
        {
            if (_buildingBehaviour != null) 
            {
                Destroy(_buildingBehaviour);
            }
            _buildingBehaviour = gameObject.AddComponent<B>();
        }
    }
}