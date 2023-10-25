using UnityEngine;

public class JorgAttack : MonoBehaviour
{
    public float attackDamage = 5f;
    public float attackRange = 1.5f; // adjusting attack range
    public float attackCooldown = 2f; // adjusting cooldown
    private float lastAttackTime = 0f;
    private GameObject player;
    private PlayerHealth playerHealth; // Reference to the PlayerHealth 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>(); // Get the PlayerHealth
        }
    }

    void Update()
    {
        if (player != null)
        {
            //player movement 
            if (Vector2.Distance(transform.position, player.transform.position) <= attackRange && Time.time - lastAttackTime > attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {

        // Damage the player
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);//player takes damage health goes down
            Debug.Log("Player hit by Jorg!");//simple debug to see if player is hit by enemy
        }
    }
}
