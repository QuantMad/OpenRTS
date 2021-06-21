using UnityEngine;

namespace Controllers.Gameplay.GameplayModes 
{
    [System.Serializable]
    public abstract class GameplayMode : MonoBehaviour
    {
        [SerializeField]
        internal GameObject DatabasesManager;      
    }
}