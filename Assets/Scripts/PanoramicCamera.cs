using UnityEngine;

public class PanoramicCamera : MonoBehaviour
{
  
    [SerializeField]
    private float lookSpeed = 2.0f;

    // To store the current rotation of the camera
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        // Apply horizontal rotation (yaw) to the Y-axis
        rotationY += mouseX;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, 0);

        // Apply vertical rotation (pitch) to the X-axis
        // We need to clamp this to prevent the camera from flipping upside down
        rotationX -= mouseY; 
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); 

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        // Press Esc to unlock cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
