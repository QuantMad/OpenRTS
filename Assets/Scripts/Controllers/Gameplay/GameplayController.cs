using Controllers.Gameplay.GameplayModes;
using UnityEngine;

namespace Controllers.Gameplay {
    public sealed class GameplayController : MonoBehaviour
    {
        public enum EGameplayMode 
        {
            free = 0,
            building = 1
        }

        [SerializeField]
        [InspectorName("Gameplay mode")]
        private EGameplayMode _Mode = EGameplayMode.building;
        public EGameplayMode Mode {
            get => _Mode;
            set {
                GameplayModes[(int) _Mode].SetActive(false);
                _Mode = value;
                GameplayModes[(int) _Mode].SetActive(true);
            }
        }
        public GameObject[] GameplayModes;

        void Start()
        {
            Mode = _Mode;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                //var gm = Mode;
                Mode = Mode == EGameplayMode.building ? EGameplayMode.free : EGameplayMode.building;
                //SwitchGameplayMode(gm);
            }
        }

        /*private void SwitchGameplayMode(EGameplayMode mode) 
        {
            GameplayModes[(int) GameplayMode].SetActive(false);
            GameplayMode = mode;
            GameplayModes[(int) GameplayMode].SetActive(true);
        }*/
    }
}