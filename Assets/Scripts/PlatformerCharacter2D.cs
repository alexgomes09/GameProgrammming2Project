﻿using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour 
{
	bool facingRight = true;							// For determining which way the player is currently facing.

	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	[SerializeField] float jumpForce = 400f;			// Amount of force added when the player jumps.	

	[Range(0, 1)]
	[SerializeField] float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	
	[SerializeField] bool airControl = false;			// Whether or not a player can steer while jumping;
	[SerializeField] LayerMask whatIsGround;			// A mask determining what is ground to the character
	
	Transform groundCheck;								// A position marking where to check if the player is grounded.
	float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
	bool grounded = false;								// Whether or not the player is grounded.
	Transform ceilingCheck;								// A position marking where to check for ceilings
	float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
	Animator anim;										// Reference to the player's animator component.
	bool isDead =false;
	private Platformer2DUserControl userControl;

    private static float playerHealth = 100;
	private static int currentLevel;
	private static int TotalScore;

    public AudioClip jumpSound;

    void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		anim = GetComponent<Animator>();
		userControl = GetComponent<Platformer2DUserControl>();
	}


	void FixedUpdate()
	{
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		//anim.SetBool("Dead", isDead);
		
		// Set the vertical animation
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
	}

	public void Move(float move, bool crouch, bool jump)
	{
		//Bo. Oct26 show debug information
		GUIText ThisText = GameObject.FindWithTag("LogOutPut").GetComponent<GUIText>() as GUIText;
		ThisText.text = "Role X:" + rigidbody2D.position.x + "...Role Y" + rigidbody2D.position.y + "...isDead :" + (isDead ? "dead" : "alive");
	    //ThisText.text = "Player Health : " + playerHealth;

		GUIText LevelNum = GameObject.FindWithTag("LevelNum").GetComponent<GUIText>() as GUIText;
		LevelNum.text = "Level : "+currentLevel.ToString ();
		GUIText PlayerHealth = GameObject.FindWithTag("PlayerHealth").GetComponent<GUIText>() as GUIText;
		PlayerHealth.text = "Health : " + playerHealth.ToString();
		// If crouching, check to see if the character can stand up
		if(!crouch && anim.GetBool("Crouch"))
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if( Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
				crouch = true;
		}

		// Set whether or not the character is crouching in the animator
		anim.SetBool("Crouch", crouch);

		//only control the player if grounded or airControl is turned on
		if(grounded || airControl)
		{
			// Reduce the speed if crouching by the crouchSpeed multiplier
			move = (crouch ? move * crouchSpeed : move);

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat("Speed", Mathf.Abs(move));

			// Move the character
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

			// If the input is moving the player right and the player is facing left...
			if(move > 0 && !facingRight)
				// ... flip the player.
				Flip();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if(move < 0 && facingRight)
				// ... flip the player.
				Flip();
		}
		if (rigidbody2D.position.y < -3.0f && !isDead) {
			//should dead
			isDead = true;
			anim.SetBool("Dead", true);
			
			userControl.GameOver();
		}


		// If the player should jump...
        if (grounded && jump) {
            // Add a vertical force to the player.
            anim.SetBool("Ground", false);
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            audio.PlayOneShot(jumpSound);
        }
	}

	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.Find("EndOfLevel1"))
        {
            Application.LoadLevel("level2");
        }
    }

    
}
