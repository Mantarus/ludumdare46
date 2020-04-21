using UnityEngine;

public class HoomanHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float saveFrame = 1f;
    public GameController gameController;
    public UIController uiController;
    
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
            uiController.SetHoomanSleep(_currentHealth);
            _lastDamageTaken = Time.time;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        gameController.GameOver();
    }
}
