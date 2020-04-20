using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator characterAnimator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2;
    public int attackDamage = 2;

    private float _lastAttack = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Time.time < _lastAttack + 1f / attackRate)
        {
            return;
        }
        
        _lastAttack = Time.time;
        characterAnimator.SetTrigger("Attack");

        var enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (var enemy in enemies)
        {
            Debug.Log("We hit enemy");
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            enemy.GetComponent<EnemyMover>().SwitchToPlayer();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
