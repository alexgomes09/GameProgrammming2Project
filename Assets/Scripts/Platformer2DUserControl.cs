﻿using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;
	private bool restart;
	private bool gameOver;

    public GameObject bulletPrefab;
    public float bulletSpeed;

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
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

        Shoot();
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
	}

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        }
    }

}
