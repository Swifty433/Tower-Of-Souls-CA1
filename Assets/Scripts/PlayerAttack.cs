using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 10f;
    public float attackRange = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse button down attacks
        {
            // calls on attack method
            Attack();
        }
    }

    //attack method is called on
    void Attack()
{

    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
    foreach (Collider2D enemyCollider in hitEnemies)
    {
        if (enemyCollider.CompareTag("Enemy") || (enemyCollider.CompareTag("Jorg") && enemyCollider.gameObject.layer == LayerMask.NameToLayer("Jorg")))
        {
            EnemyAi enemyAi = enemyCollider.GetComponent<EnemyAi>();
            Jorg jorgAi = enemyCollider.GetComponent<Jorg>();
            
            //enemy loses health from player
            if (enemyAi != null)
            {
                enemyAi.TakeDamage(attackDamage);
                Debug.Log("Enemy hit by Player!");
            }
            // jorg ai loses helth from player
            else if (jorgAi != null)
            {
                jorgAi.TakeDamage(attackDamage);
                Debug.Log("Jorg hit by Player!");
            }
        }
    }
}
}
