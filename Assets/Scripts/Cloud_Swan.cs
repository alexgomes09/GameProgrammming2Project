using System;
using UnityEngine;

public class Cloud_Swan : MonoBehaviour
{
    private GameObject player;
    public GameObject rocket;
    private GameObject swan,cloud,cloud2,cloud3;
    private const float cloudSpeed = 0.8f;
    private const float swanSpeed = 0.8f;
    private Vector2 screenPositionforSwan;
    private bool dropBomb;

    void Start()
	{
	    player = GameObject.Find("Player");
        swan = GameObject.Find("swan");
        cloud = GameObject.Find("cloud");
        cloud2 = GameObject.Find("cloud2");
        cloud3 = GameObject.Find("cloud3");
        rocket = GameObject.Find("rocket");
	}

    private void Update()
    {
        MoveCloud();
        MoveSwan();
        MoveRocket();
    }

    void MoveCloud()
    {
        Vector2 screenPositionforCloud = Camera.main.WorldToScreenPoint(cloud.transform.position);
        Vector2 screenPositionforCloud2 = Camera.main.WorldToScreenPoint(cloud2.transform.position);
        Vector2 screenPositionforCloud3 = Camera.main.WorldToScreenPoint(cloud3.transform.position);
        if (renderer.isVisible)
        {
            cloud.transform.Translate(-Vector2.right * Time.deltaTime * cloudSpeed);
            cloud2.transform.Translate(Vector2.right * Time.deltaTime * cloudSpeed);
            cloud3.transform.Translate(-Vector2.right * Time.deltaTime * cloudSpeed);
        }
        if (screenPositionforCloud.x < 0)
        {
            cloud.transform.position = new Vector2(player.transform.position.x + 15, player.transform.position.y + 6.5f);
        }
        if(screenPositionforCloud2.x > Screen.width) 
        {
            cloud2.transform.position = new Vector2(player.transform.position.x - 20, player.transform.position.y + 7);
        }
        if (screenPositionforCloud3.x+cloud3.renderer.bounds.size.y < 0 )
        {
            cloud3.transform.position = new Vector2(player.transform.position.x + 20, player.transform.position.y + 7);
        }
    }

    void MoveSwan()
    {
        screenPositionforSwan = Camera.main.WorldToScreenPoint(swan.transform.position);
        swan.transform.Translate(-Vector2.right * Time.deltaTime * swanSpeed);
        
        if (screenPositionforSwan.x < 0) 
        {
            swan.transform.position = new Vector2(player.transform.position.x + 15, player.transform.position.y + 6.5f);
			rocket.SetActive(true);
        }

        
    }

    void MoveRocket()
    {
        if (swan.transform.position.x <= player.transform.position.x)
        {
			if(rocket != null){
	            rocket.rigidbody2D.AddForce(-Vector2.up*2.0f, ForceMode2D.Force);
			}
        }
        else
        {
            rocket.transform.position = swan.transform.position;    
        }
    }


}
