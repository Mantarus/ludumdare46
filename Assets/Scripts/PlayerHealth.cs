using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 9;
    public float saveFrame = 0.5f;

    private int _currentHealth;
    private float _lastDamageTaken = 0f;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_lastDamageTaken + saveFrame < Time.time)
        {
            _currentHealth -= damage;
            _lastDamageTaken = Time.time;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
