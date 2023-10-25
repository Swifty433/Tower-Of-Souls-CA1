using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeedMultiplier = 2f;
    public float maxStamina = 100f;
    public float sprintStaminaCost = 10f;
    public float staminaRecoveryRate = 5f;
    public float sprintDuration = 2f;
    public float currentStamina;
    private bool isSprinting = false;
    private float sprintTimer = 0f;

    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    private Vector2 lastDirection = Vector2.down;

    public Slider staminaSlider; // Stamina bar slider (not implmented)

    // called right away
    void Start()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprinting();//sprinting method called
        UpdateMovementAnimation();//moveAnimation method called
    }

    //sprint method
    private void UpdateSprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))//keybinds to toggle sprint
        {
            if (currentStamina > 0)
            {
                isSprinting = true;
                currentStamina -= sprintStaminaCost * Time.deltaTime;
                sprintTimer += Time.deltaTime;

                if (sprintTimer > sprintDuration)
                {
                    isSprinting = false;
                    sprintTimer = 0f;
                }
            }
            else
            {
                isSprinting = false;
            }
        }
        else
        {
            isSprinting = false;
            if (currentStamina < maxStamina)
            {
                currentStamina += staminaRecoveryRate * Time.deltaTime;
                currentStamina = Mathf.Min(currentStamina, maxStamina); // Ensure the current stamina doesn't exceed the maximum value
            }
        }
    }

    private void UpdateMovementAnimation()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            lastDirection = movement.normalized;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }

        if (movement == Vector2.zero)
        {
            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
        }
    }

    void FixedUpdate()
    {
        float currentMoveSpeed = isSprinting ? moveSpeed * sprintSpeedMultiplier : moveSpeed;
        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }
}
