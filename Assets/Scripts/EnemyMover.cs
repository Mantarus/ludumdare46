using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform player;
    public Transform bed;
    public float aggroSpan = 3f;

    public float speed = 1;

    private Transform _target;
    private Rigidbody2D _rb;
    private bool _facingRight = true;
    private float _lastSwitchToPlayer = 0f;

    private void Start()
    {
        _target = bed;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var direction = Mathf.Sign((_target.position - transform.position).x);
        _rb.velocity = Vector2.right * (direction * speed);

        if (direction > 0 && !_facingRight || direction < 0 && _facingRight)
        {
            Flip();
        }

        if (_lastSwitchToPlayer + aggroSpan < Time.time)
        {
            SwitchToBed();
        }
    }
    
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        _facingRight = !_facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SwitchToPlayer()
    {
        _target = player;
        _lastSwitchToPlayer = Time.time;
    }

    public void SwitchToBed()
    {
        _target = bed;
    }
}
