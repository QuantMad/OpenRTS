using Controllers.Gameplay.GameplayModes;
using UnityEngine;

namespace Controllers.Gameplay {
    public class GameplayController : MonoBehaviour
    {
        public enum EGameplayMode 
        {
            free = 0,
            building = 1
        }

        [SerializeField]
        private EGameplayMode GameplayMode = EGameplayMode.free;
        public GameObject[] GameplayModes;

        private GameObject _gameplayMode;

        void Start()
        {
            SwitchGameplayMode(GameplayMode);
        }

        void Update()
        {
            
        }

        private void SwitchGameplayMode(EGameplayMode mode) 
        {
            int index = (int) (GameplayMode = mode);
            if (_gameplayMode != null) Destroy(_gameplayMode);
            _gameplayMode = Instantiate(GameplayModes[index], transform);
        }
    }
}