namespace Controllers.Gameplay.GameplayModes 
{
    [System.Serializable]
    public sealed class GameplayModeFree : GameplayMode
    {
        void Start() {
            
        }

        void OnEnable() {
            //Debug.Log("Free mode activated");
        }

        void OnDisable()
        {
            //Debug.Log("Free mode deactivated");
        }
    }
}