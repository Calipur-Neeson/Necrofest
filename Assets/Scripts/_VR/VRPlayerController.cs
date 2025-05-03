using UnityEngine;
using UnityEngine.InputSystem;

public class VRPlayerController : MonoBehaviour
{
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private float jumpHeight = 3.0f;
    private CharacterController cc;
    [SerializeField] private LayerMask groundLayer;
    private float gravity = Physics.gravity.y;

    private Vector3 move;
    private int jumpNum = 0;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        bool isGround = IsGround();

        if (isGround)
        {
            jumpNum = 0;
        }
        if (jumpNum < 2 && jumpButton.action.WasPressedThisFrame())
        {
            Jump();
            jumpNum++;
        }
        
        move.y += gravity * Time.deltaTime;
        cc.Move(move * Time.deltaTime);
    }
    private void Jump()
    {
        move.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }
    private bool IsGround()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayer);
    }
}
