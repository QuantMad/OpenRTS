using Buildings;
using Buildings.Behaviours;
using Buildings.Civils;
using Dadabases;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controllers.Gameplay.GameplayModes 
{
    [System.Serializable]
    public sealed class GameplayModeBuilding : GameplayMode
    {
        private const float GridStep = .2f;

        [SerializeField]
        private GameObject Database;
        private DatabaseBuildings db;
        public GameObject[] Buildings { get; private set; }
        public int BuildingsCount => Buildings.Length - 1;

        private int _Index = -1;
        private int Index
        {
            get => _Index;
            set
            {
                int prevIndex = _Index;
                _Index = value < 0 ? BuildingsCount : value > BuildingsCount ? 0 : value;

                ChangePreviewBuilding(prevIndex);
            }
        }

        public GameObject Selected => Index != -1 ? Buildings[Index] : null;

        private GameObject _PreviewBuilding;
        private GameObject PreviewBuilding
        {
            get => _PreviewBuilding;
            set
            {
                if (_PreviewBuilding != null)
                    Destroy(_PreviewBuilding);
                _PreviewBuilding = value;
                _PreviewBuilding.transform.SetParent(transform);
            }
        }
        
        void Start()
        {
            db = Database.GetComponent<DatabaseBuildings>();
            Buildings = db.GetRecords();
            Index = 0;
        }

        void OnEnable() {
            
        }

        void OnDisable()
        {
            
        }

        void Update()
        {
            ChooseBuilding();
            
            if (EventSystem.current.IsPointerOverGameObject()) return;
            Ray mouseRay = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(mouseRay);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.layer == 3)
                {
                    MovePriviewBuilding(hit.point);
                    PlaceBuilding();
                    PreviewBuildingRotation();

                    break;
                }
            }
        }

        private void PreviewBuildingRotation()
        {
            float d = -Input.mouseScrollDelta.y;

            if (d == 0f) return;

            PreviewBuilding.GetComponent<PlacementBehaviour>().Rotate(d < 0 ? -22.5f : 22.5f);
        }

        private void ChooseBuilding()
        {
            if (Input.GetKeyUp(KeyCode.A))
                Index -= 1;
            else if (Input.GetKeyUp(KeyCode.D))
                Index+=1;
        }

        private void ChangePreviewBuilding(int prevIndex)
        {
            if (Selected == null || prevIndex == _Index) return;

            GameObject newPreviewBuilding = Instantiate(Selected);
            
            newPreviewBuilding.GetComponent<SuperBuilding>().SetGameplayMode<PlacementBehaviour>();
            if (PreviewBuilding != null)
            {
                newPreviewBuilding.transform.position = PreviewBuilding.transform.position;
                newPreviewBuilding.transform.rotation = PreviewBuilding.transform.rotation;
            }
            PreviewBuilding = newPreviewBuilding;
            PreviewBuilding.SetActive(true);
        }

        private void MovePriviewBuilding(Vector3 mouseWorldPoint)
        {
            if (PreviewBuilding == null) return;

            Vector3 relativePoint = mouseWorldPoint;
            float xSolid = (int)(relativePoint.x / GridStep) * GridStep;
            float zSolid = (int)(relativePoint.z / GridStep) * GridStep;

            relativePoint.x = (GridStep - (relativePoint.x - xSolid)) > (GridStep / 2) ? xSolid : xSolid + GridStep;
            relativePoint.z = (GridStep - (relativePoint.z - zSolid)) > (GridStep / 2) ? zSolid : zSolid + GridStep;
            relativePoint.y += PreviewBuilding.GetComponent<Renderer>().bounds.size.y / 2;

            if (PreviewBuilding.transform.position != relativePoint)
                PreviewBuilding.transform.position = relativePoint;
        }

        private void PlaceBuilding()
        {
            if (!Input.GetMouseButtonUp(0) || Selected == null) return;

            if (!PreviewBuilding.GetComponent<PlacementBehaviour>().CanBePlaced)
                return;

            GameObject newBuilding = Instantiate(Selected);
            newBuilding.GetComponent<SuperBuilding>().SetGameplayMode<GameplayBehaviour>();
            newBuilding.transform.position = PreviewBuilding.transform.position;
            newBuilding.transform.rotation = PreviewBuilding.transform.rotation;
            newBuilding.SetActive(true);
        }

        public void SetSelectedBuilding(string name)
        {
            for (int i = 0; i <= BuildingsCount; i++)
            {
                if (Buildings[i].name == name)
                {
                    Index = i;
                    return;
                }
            }
        }

        void OnDestroy()
        {
            Destroy(PreviewBuilding);
        }

        /*public override Modes GetMode()
        {
            return Modes.Building;
        }*/
    }
}