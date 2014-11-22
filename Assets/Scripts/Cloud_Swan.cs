using UnityEngine;

public class Cloud_Swan : MonoBehaviour
{
    private GameObject player;
    public GameObject swan,cloud;
    private const float cloudSpeed = 1.2f;

    void Start ()
	{
	    player = GameObject.Find("Player");
        swan = GameObject.Find("swan");
	    cloud= GameObject.Find("cloud");
	}

    private void Update()
    {
        MoveCloud();
    }

    void MoveCloud()
    {
        cloud.transform.Translate(-Vector2.right * Time.deltaTime*cloudSpeed);
    }

    void OnBecameInvisible()
    {
        if (cloud.transform.position.x < 0)
        {
            cloud.transform.position = new Vector2(player.transform.position.x+14,player.transform.position.y+5);
            Debug.Log(Camera.main.aspect);
            Debug.Log(Screen.height);
        }
    }
}
