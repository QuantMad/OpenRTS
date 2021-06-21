using Buildings;
using Buildings.Behaviours;
using Databases;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controllers.Gameplay.GameplayModes 
{
    [System.Serializable]
    public sealed class GameplayModeBuilding : GameplayMode
    {
        private const float GridStep = .2f; /// TODO: Вынести сетку в отдельный объект

        [SerializeField]
        private GameObject Database;
        private DatabaseBuildings db;

        private int _Index = -1;
        private int Index
        {
            get => _Index;
            set
            {
                //if (db == null) return;
                int prevIndex = _Index;
                _Index = value < 0 ? db.ItemsCount - 1 : value > db.ItemsCount - 1 ? 0 : value;

                ChangePreviewBuilding(prevIndex);
            }
        }

        //public GameObject Selected => Index != -1 ? db.Civils[Index] : null;
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
            db = DatabasesManager.GetComponent<DatabasesManager>().Civils;
            Index = 0;
        }

        void OnEnable() {
            if (db != null) Index = 0;
        }

        void OnDisable()
        {
            Destroy(PreviewBuilding);
            _Index = -1;
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
            if (prevIndex == Index || _Index == -1) return;

            GameObject newPreviewBuilding = Instantiate(db.records[Index]);
            
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
            //relativePoint.y += PreviewBuilding.GetComponent<Renderer>().bounds.size.y / 2;

            if (PreviewBuilding.transform.position != relativePoint)
                PreviewBuilding.transform.position = relativePoint;
        }

        private void PlaceBuilding()
        {
            if (!Input.GetMouseButtonUp(0) || Index == -1) return;

            if (!PreviewBuilding.GetComponent<PlacementBehaviour>().CanBePlaced)
                return;

            GameObject newBuilding = Instantiate(db.records[Index]);
            newBuilding.GetComponent<SuperBuilding>().SetGameplayMode<GameplayBehaviour>();
            newBuilding.transform.position = PreviewBuilding.transform.position;
            newBuilding.transform.rotation = PreviewBuilding.transform.rotation;
            newBuilding.SetActive(true);
        }

        /*public void SetSelectedBuilding(string name)
        {
            for (int i = 0; i <= BuildingsCount; i++)
            {
                if (db.records[i].name == name)
                {
                    Index = i;
                    return;
                }
            }
        }*/

        void OnDestroy()
        {
            
        }
    }
}