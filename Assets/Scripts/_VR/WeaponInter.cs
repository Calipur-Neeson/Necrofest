using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeaponInter : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatAmplitude = 0.1f;
    public float floatFrequency = 1f;

    private XRGrabInteractable grabInteractable;
    private bool isGrabed;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (!isGrabed)
        {
            HangingThere();
        }
    }
    private void HangingThere()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.up, Vector3.right);
        float newY = 1 + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
    public void OnSelectEnter()
    {
        isGrabed = true;
    }
    public void OnSelectExit()
    {
        startPos = transform.position;
        isGrabed = false;
    }  
}
