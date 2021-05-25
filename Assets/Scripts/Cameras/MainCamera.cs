using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCamera : MonoBehaviour
{
    private const int MOUSE_BUTTON_LEFT = 0;
    private const int MOUSE_BUTTON_RIGHT = 1;
    private const int MOUSE_BUTTON_MIDDLE = 2;

    [Range(0, 10)]
    public float DraggingSpeed = 1;

    private bool isOnDragging = false;

    void Start()
    {

    }

    void Update()
    {
        CameraDragging();
    }

    /* Перемещение камеры мышью */
    private void CameraDragging() {
        if (!Input.GetMouseButton(MOUSE_BUTTON_RIGHT)) {
            isOnDragging = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }

        if (!isOnDragging) {
            isOnDragging = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return;
        }

        Vector3 newPos = transform.position;
        newPos.x += Input.GetAxis("Mouse X") * DraggingSpeed;
        newPos.z += Input.GetAxis("Mouse Y") * DraggingSpeed;
        
        transform.position = newPos;
    }
}
