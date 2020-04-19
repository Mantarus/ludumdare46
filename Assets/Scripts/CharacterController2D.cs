using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	public Animator characterAnimator;
	public float jumpForce = 400f;							// Amount of force added when the player jumps.
    [Range(0, .3f)] public float movementSmoothing = .05f;	// How much to smooth out the movement
	public bool airControl = false;							// Whether or not a player can steer while jumping;
	public LayerMask whatIsGround;							// A mask determining what is ground to the character
	public Transform groundCheck;							// A position marking where to check if the player is grounded.
	
	private const float GroundedRadius = .2f;				// Radius of the overlap circle to determine if grounded
	private bool _grounded;									// Whether or not the player is grounded.
	private Rigidbody2D _rigidbody2D;
	private bool _facingLeft = true;						// For determining which way the player is currently facing.
	private Vector3 _velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent onLandEvent;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();

		if (onLandEvent == null)
			onLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		var wasGrounded = _grounded;
		_grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		var colliders = Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius, whatIsGround);
		foreach (var col in colliders)
		{
			if (col.gameObject == gameObject) continue;
			_grounded = true;
			if (!wasGrounded) onLandEvent.Invoke();
		}
	}


	public void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (_grounded || airControl)
		{
			characterAnimator.SetFloat("Speed", Mathf.Abs(move));
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			_rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref _velocity, movementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && _facingLeft)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && !_facingLeft)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (_grounded && jump)
		{
			// Add a vertical force to the player.
			_grounded = false;
			_rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}

		characterAnimator.SetBool("IsJumping", !_grounded);
		characterAnimator.SetFloat("VerticalSpeed", _rigidbody2D.velocity.y);
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		_facingLeft = !_facingLeft;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
