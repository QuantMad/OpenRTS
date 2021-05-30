using UnityEngine;

namespace Cameras 
{
    [RequireComponent(typeof(Camera))]
    public class MainCamera : MonoBehaviour
    {
        public bool DraggingLock = false;
        [Range(0, 2)]
        public float DraggingSpeed = 1;
        public bool ApproximationLock = false;
        [Range(0, 2)]
        public float ApproximationSpeed = 1;

        private bool isOnDragging = false;
        private Camera _MainCamera;

        void Start()
        {
            _MainCamera = GetComponent<Camera>();
        }

        void Update()
        {
            CameraDragging();
            Approximation();
        }

        /* Перемещение камеры мышью */
        private void CameraDragging() {
            if (DraggingLock) return;

            if (!Input.GetMouseButton(1)) {
                isOnDragging = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                return;
            }

            if (!isOnDragging) {
                isOnDragging = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
            }

            Vector3 newPos = transform.position;
            newPos.x += Input.GetAxis("Mouse X") * DraggingSpeed;
            newPos.z += Input.GetAxis("Mouse Y") * DraggingSpeed;
            
            transform.position = newPos;
        }

    /* TODO: Сделать честное приближение/отдаление камеры */
        private void Approximation() {
            if (ApproximationLock) return;

            if (Input.mouseScrollDelta.y == 0) return;

            float fov = _MainCamera.fieldOfView;
            float newValue = fov + (Input.mouseScrollDelta.y > 0 ? -ApproximationSpeed : ApproximationSpeed);
            fov = Mathf.Clamp(newValue, 20, 60);
            _MainCamera.fieldOfView = fov;
        }
    }
}