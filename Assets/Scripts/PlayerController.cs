using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerInput.MainActions input;

    CharacterController controller;
    public Animator animator;
    AudioSource audioSource;

    [Header("Controller")]
    public float moveSpeed = 5;
    public float gravity = -9.8f;
    public float jumpHeight = 1.2f;
    
    [Header("Dash")]
    public float dashSpeed = 10.0f;
    public float dashEnergyDrainRate = 10.0f;
    public float maxDashEnergy = 100.0f;
    public float dashEnergyCost = 60.0f;
    public Slider dashSlider;
    float currentDashEnergy;

    [Header("Run")]
    public float runSpeed = 20.0f;
    public float maxRunEnergy = 100.0f;
    public float runEnergyDrainRate = 5.0f;
    public float runEnergyRegenRate = 5.0f;
    public Slider runSlider;
    float currentRunEnergy;
    
    Vector3 _PlayerVelocity;

    bool isGrounded;
    bool isRun;

    [Header("Camera")]
    public Camera cam;
    public float sensitivity;

    float xRotation = 0f;
    int jumpCount = 0;
    float moveSpeed_temp = 0f;

    void Awake()
    { 
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        playerInput = new PlayerInput();
        input = playerInput.Main;
        AssignInputs();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        moveSpeed_temp = moveSpeed;
        dashSlider.maxValue = maxDashEnergy;
        dashSlider.value = maxDashEnergy;
        currentDashEnergy = maxDashEnergy;
        
        isRun = true;
        runSlider.maxValue = maxRunEnergy;
        runSlider.value = maxRunEnergy;
        currentRunEnergy = maxRunEnergy;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        //Debug.Log(isGrounded);
        // Repeat Inputs
        if(input.Attack.IsPressed())
        { Attack(); }
        
        SetAnimations();
    }

    void FixedUpdate()
    {
        MoveInput(input.Movement.ReadValue<Vector2>()); 
    }
    
    void LateUpdate() 
    { LookInput(input.Look.ReadValue<Vector2>()); }

    void MoveInput(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        
        RegenRunEnergy();
        RegenDashEnergy();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            FastMove();
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            Dash();
        }
        else
        {
            isRun = false; 
            moveSpeed = moveSpeed_temp;
        }
        
        controller.Move(transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        _PlayerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && _PlayerVelocity.y < 0)
            _PlayerVelocity.y = -2f;
        controller.Move(_PlayerVelocity * Time.deltaTime);
    }

    void LookInput(Vector3 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime * sensitivity);
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * sensitivity));
    }

    void OnEnable() 
    { input.Enable(); }

    void OnDisable()
    { input.Disable(); }

    void Dash()
    {
        Vector2 inputVector = new Vector2();
        inputVector = playerInput.Main.Movement.ReadValue<Vector2>();
        if (inputVector.x != 0 || inputVector.y != 0)
        {
            if (currentDashEnergy > dashEnergyCost)
            {
                moveSpeed = dashSpeed;
                currentDashEnergy -= dashEnergyCost;
            }
        }
    }

    private void RegenDashEnergy()
    {
        if (currentDashEnergy <= dashSlider.maxValue)
        {
            currentDashEnergy += dashEnergyDrainRate * Time.deltaTime;
            dashSlider.value = currentDashEnergy;
        }
    }

    void FastMove()
    {
        isRun = true;
        if (currentRunEnergy > 1.0f)
        {
            moveSpeed = runSpeed;
            currentRunEnergy -= runEnergyDrainRate * Time.deltaTime;
            runSlider.value = currentRunEnergy;
        }
        else
        {
            moveSpeed = moveSpeed_temp;
        }
    }

    private void RegenRunEnergy()
    {
        if (isRun == false)
        {
            if (currentRunEnergy <= runSlider.maxValue)
            {
                currentRunEnergy += runEnergyRegenRate * Time.deltaTime;
                runSlider.value = currentRunEnergy;
            }
            
        }
    }
    void Jump()
    {
        // Adds force to the player rigidbody to jump
        if (isGrounded)
        {
            _PlayerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            jumpCount++;
        }
        else if (!isGrounded && jumpCount > 0)
        {
            _PlayerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            jumpCount = 0;
        }
    }

    void AssignInputs()
    {
        input.Jump.performed += ctx => Jump();
        input.Attack.started += ctx => Attack();
    }

    // ---------- //
    // ANIMATIONS //
    // ---------- //

    public const string IDLE = "Idle";
    public const string WALK = "Walk";
    public const string ATTACK1 = "Attack 1";
    public const string ATTACK2 = "Attack 2";

    string currentAnimationState;

    public void ChangeAnimationState(string newState) 
    {
        // STOP THE SAME ANIMATION FROM INTERRUPTING WITH ITSELF //
        if (currentAnimationState == newState) return;

        // PLAY THE ANIMATION //
        currentAnimationState = newState;
        animator.CrossFadeInFixedTime(currentAnimationState, 0.2f);
    }

    void SetAnimations()
    {
        // If player is not attacking
        if(!attacking)
        {
            if(_PlayerVelocity.x == 0 &&_PlayerVelocity.z == 0)
            { ChangeAnimationState(IDLE); }
            else
            { ChangeAnimationState(WALK); }
        }
    }

    // ------------------- //
    // ATTACKING BEHAVIOUR //
    // ------------------- //

    [Header("Attacking")]
    public float attackDistance = 3f;
    public float attackDelay = 0.4f;
    public float attackSpeed = 1f;
    public float attackDamage = 1;
    public LayerMask attackLayer;

    public GameObject hitEffect;
    public AudioClip swordSwing;
    public AudioClip hitSound;

    bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    public void Attack()
    {
        if(!readyToAttack || attacking) return;

        readyToAttack = false;
        attacking = true;

        Invoke(nameof(ResetAttack), attackSpeed);
        Invoke(nameof(AttackRaycast), attackDelay);

        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(swordSwing);

        if(attackCount == 0)
        {
            ChangeAnimationState(ATTACK1);
            attackCount++;
        }
        else
        {
            ChangeAnimationState(ATTACK2);
            attackCount = 0;
        }
    }

    void ResetAttack()
    {
        attacking = false;
        readyToAttack = true;
    }

    void AttackRaycast()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, attackDistance, attackLayer))
        { 
            HitTarget(hit.point);

            if(hit.transform.TryGetComponent<Actor>(out Actor T))
            { T.TakeDamage(attackDamage); }
        } 
    }

    void HitTarget(Vector3 pos)
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(hitSound);

        GameObject GO = Instantiate(hitEffect, pos, Quaternion.identity);
        Destroy(GO, 20);
    }
}