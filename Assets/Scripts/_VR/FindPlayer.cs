using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    private Vector3 parentPos;

    private void Update()
    {
        parentPos = transform.parent.position;
        transform.position = parentPos;
    }
}
