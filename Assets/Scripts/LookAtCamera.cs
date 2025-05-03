using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = FindFirstObjectByType<Camera>();
    }
    private void LateUpdate()
    {
        Vector3 cameraPosition = _mainCamera.transform.position;

        cameraPosition.y = transform.position.y;

        transform.LookAt(cameraPosition);

        transform.Rotate(0f, 180f, 0f);
    }
}
