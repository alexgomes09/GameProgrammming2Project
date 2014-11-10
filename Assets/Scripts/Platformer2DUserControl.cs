using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;
	private bool restart;
	private bool gameOver;

    public GameObject bulletPrefab;
    public float nextFire = 0.01f;
    float timer = 0f;

	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
		restart = false;
		gameOver = false;
	}

    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
#if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
#else
		if (Input.GetButtonDown("Jump")) jump = true;
#endif
		//
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
        Shoot();

		GUIText TotalTime = GameObject.FindWithTag("TotalTime").GetComponent<GUIText>() as GUIText;
		TotalTime.text = "TotalTime : " + Time.realtimeSinceStartup.ToString ();
    }

	void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif

		// Pass all parameters to the character control script.
		character.Move( h, crouch , jump );

        // Reset the jump input once it has been used.
	    jump = false;

		if (gameOver)
		{
			restart = true;
		}
	}

	public void GameOver ()
	{
		gameOver = true;
		GUIText gameOverText = GameObject.FindWithTag("GameOver").GetComponent<GUIText>() as GUIText;
		gameOverText.text = "Game Over, Press R to restart";
	}

    void Shoot()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer > nextFire)
        {
            Instantiate(bulletPrefab,transform.position,Quaternion.identity);
            timer = 0;
            Physics2D.IgnoreCollision(bulletPrefab.collider2D, collider2D);
        }
    }

}
