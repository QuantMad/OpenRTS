using UnityEngine;

namespace Controllers.Gameplay.GameplayModes 
{
    public abstract class GameplayMode : MonoBehaviour
    {
        [SerializeField]
        internal GameObject DatabasesManager;        
    }
}