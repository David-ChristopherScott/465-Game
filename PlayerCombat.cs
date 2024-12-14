using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim; // Attack Animator 
    public float attackRange = 1.5f; // Attack Range 
    public LayerMask enemyLayer; // Enemy Identifiers
    public GameObject destructionEffect; // Ememy Death
    public GameObject Brush; // Brush Spawner
    private int slime = 0; // Kill count 

    public void Attack()
    {
        anim.SetBool("IsAttacking", true);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Check to see if it's an enemy 
            if (enemyCollider != null)
            {
                GameObject enemy = enemyCollider.gameObject;

                // Starts death animation
                if (destructionEffect != null)
                {
                    Instantiate(destructionEffect, enemy.transform.position, Quaternion.identity);
                }

                // Slime Kill count 
                slime++;
                if (slime % 10 == 0 && Brush != null)
                {
                    Instantiate(Brush, transform.position, Quaternion.identity);
                }

                // Destroy the enemy GameObject
                Destroy(enemy);
            }
        }

        StartCoroutine(ResetAttackAnimation());
    }

    private IEnumerator ResetAttackAnimation()
    {
        //Wait for the animation to stop 
        yield return new WaitForSeconds(0.5f);

        // Reset it to fale 
        anim.SetBool("IsAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        //This draws a red sphere to show you the attack range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
