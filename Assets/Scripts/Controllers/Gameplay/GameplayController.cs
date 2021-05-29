using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public enum EGameplayMode {
        free = 0,
        building = 1
    }
    
    public GameObject[] GameplayModes;

    [SerializeField]
    private EGameplayMode GameplayMode = EGameplayMode.free;
    private GameObject _GameplayMode;

    void Start()
    {
        SwitchGameplayMode(GameplayMode);
    }

    void Update()
    {
        
    }

    private void SwitchGameplayMode(EGameplayMode mode) {
        GameplayMode = mode;
        int index = (int) GameplayMode;
        if (_GameplayMode != null) Destroy(_GameplayMode);
        _GameplayMode = Instantiate(GameplayModes[index], transform);
    }
}
