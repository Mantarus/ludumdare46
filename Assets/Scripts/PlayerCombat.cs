using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator characterAnimator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
    }

    private void Attack()
    {
        characterAnimator.SetTrigger("Attack");

        var enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (var enemy in enemies)
        {
            Debug.Log("We hit enemy");
            enemy.GetComponent<EnemyHealth>().TakeDamage(2);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
