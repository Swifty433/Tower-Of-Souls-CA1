using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    private Vector3 dir;
    private Vector2 lastDirection = Vector2.down;

    private bool isInChaseRange;
    private bool isInAttackRange;

    public float health = 50f;

    private GameManager gameManager; //refrence to the game manager script

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        anim.SetBool("isRunning", isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
    }

    //if the enemy is in range of player and attacking distance move player
    //otherwise return to idol animation
    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter();
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }


    private void MoveCharacter()
    {
        //updates the position of the rigid body
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        AnimateCharacter();
    }

    private void AnimateCharacter()
    {
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        //Set the direction of the player to the last direction it was.
        if (movement != Vector2.zero)
        {
            lastDirection = movement.normalized;
        }
        //Set the direction of the enemy to the last direction it was.
        if (movement == Vector2.zero)
        {
            anim.SetFloat("Horizontal", lastDirection.x);
            anim.SetFloat("Vertical", lastDirection.y);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //if health drops below 0
        if (health <= 0)
        {
            //goes to die class and then deletes game object
            Die();
        }
    }

    private void Die()
    {
        //calls the defeated enemy method in gameManager
        gameManager.EnemyDefeated();
        //Enemy Dies
        Destroy(gameObject); 
    }
}
