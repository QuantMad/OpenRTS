using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public enum EGameplayMode {
        free = 0,
        building = 1
    }
    public GameObject[] GameplayModes;
    public EGameplayMode GameplayMode;
    private GameObject _GameplayMode;

    // Start is called before the first frame update
    void Start()
    {
        int index = (int) GameplayMode;
        _GameplayMode = Instantiate(GameplayModes[index], transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SwitchGameplayMode() {
        int index = (int) GameplayMode;
        if (_GameplayMode == null) {
            _GameplayMode = Instantiate(GameplayModes[index], transform);
            return;
        }
    }
}
