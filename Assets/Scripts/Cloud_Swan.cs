using UnityEngine;

public class Cloud_Swan : MonoBehaviour
{
    private GameObject player;
    private GameObject swan,cloud,cloud2,cloud3;
    private const float cloudSpeed = 0.8f;
    private const float swanSpeed = 0.8f;

    void Start()
	{
	    player = GameObject.Find("Player");
        swan = GameObject.Find("swan");
        cloud = GameObject.Find("cloud");
        cloud2 = GameObject.Find("cloud2");
        cloud3 = GameObject.Find("cloud3");
	}

    private void Update()
    {
        MoveCloud();
        MoveSwan();
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
        Vector2 screenPositionforSwan = Camera.main.WorldToScreenPoint(swan.transform.position);
        //swan.transform.Translate(-Vector2.right * Time.deltaTime * swanSpeed);

        if (screenPositionforSwan.x < 0)
        {
            swan.transform.localScale = new Vector2(-1, 1);
            swan.transform.position =
                new Vector2(Mathf.MoveTowards(swan.transform.position.x, player.transform.position.x - 15, swanSpeed * Time.deltaTime), 4);
        }else if (screenPositionforSwan.x > Screen.width)
        {
            swan.transform.localScale = new Vector2(1, 1);
            swan.transform.position =
                new Vector2(Mathf.MoveTowards(swan.transform.position.x, player.transform.position.x + 15, swanSpeed * Time.deltaTime), 4);
        }
        
    }
}
