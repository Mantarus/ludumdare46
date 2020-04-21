using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int hitDamage = 1;
    public int hoomanDamage = 20;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (LayerMask.NameToLayer("Player") == other.gameObject.layer)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(hitDamage);
        }
        if (LayerMask.NameToLayer("Hooman") == other.gameObject.layer)
        {
            other.gameObject.GetComponent<HoomanHealth>().TakeDamage(hoomanDamage);
            gameObject.SetActive(false);
        }
    }
}
