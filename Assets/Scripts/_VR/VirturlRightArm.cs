using UnityEngine;
using UnityEngine.XR;

public class VirturlRightArm : MonoBehaviour
{
    public XRNode controllerNode = XRNode.RightHand;
    private Transform thisTransform;

    void Start()
    {
        thisTransform = transform;
    }

    void Update()
    {
        InputDevices.GetDeviceAtXRNode(controllerNode).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(controllerNode).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        thisTransform.position = position;
        thisTransform.rotation = rotation;
    }
}
