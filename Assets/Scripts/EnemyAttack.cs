using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //all editable withtin the unity editor
    public float attackDamage = 5f; //Attack Damage of the enemy
    public float attackRange = 1.5f; //Attack range of enemy
    public float attackCooldown = 2f; // Attack cooldown timer
    
    private float lastAttackTime = 0f;
    private GameObject player;
    private PlayerHealth playerHealth; // player health variable

    void Start()
    {
        //finds the player game object 
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>(); 
        }
    }

    void Update()
    {
        if (player != null)
        {
            //When player is within range of enemy enemy moves towards the player
            if (Vector2.Distance(transform.position, player.transform.position) <= attackRange && Time.time - lastAttackTime > attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        // Causes Damage to the playyer
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Player hit by Enemy!");
        }
    }
}
