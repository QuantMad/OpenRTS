using UnityEngine;

namespace Buildings
{
    /// FIXME: Переделать в интерфейс?
    /** Базовый, элементарный класс, определяющий абстракцию здания. Костыль, грубо говоря.
        Нужен для деформализации при десериализации объекта **/
    public abstract class SuperBuilding : MonoBehaviour
    {
        public abstract void DeserializeProperties(string json);
    }
}
