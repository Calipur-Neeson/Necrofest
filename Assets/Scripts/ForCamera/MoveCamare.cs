using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveCamare : MonoBehaviour
{
    public Transform cameraTransform; // 拖入 Main Camera
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;

    private float pitch = 0f; // 俯仰（上下）
    private float yaw = 0f;   // 偏航（左右）

    private bool isPaused;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = cameraTransform.localEulerAngles.x;
    }

    void Update()
    {
        // 移动控制
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float upDown = 0;

        if (Input.GetKey(KeyCode.E)) upDown = 1;
        else if (Input.GetKey(KeyCode.Q)) upDown = -1;

        Vector3 move = new Vector3(h, upDown, v);
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);

        // 旋转控制（鼠标右键按下时）
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

            yaw += mouseX;
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -89f, 89f); // 限制俯仰角度，避免翻转

            transform.rotation = Quaternion.Euler(0, yaw, 0);
            cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            { 
                Pause();
            }
          else { Resume();}
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
