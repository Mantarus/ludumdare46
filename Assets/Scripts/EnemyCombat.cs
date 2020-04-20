using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int hitDamage = 1;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (LayerMask.NameToLayer("Player") == other.gameObject.layer)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(hitDamage);
        }
    }
}
