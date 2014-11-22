using UnityEditor;
using UnityEngine;
using System.Collections;

public class Cloud_Swan : MonoBehaviour
{
    private GameObject player;
    public GameObject swan,cloud;
    public float cloudSpeed = .5f;

	void Start ()
	{
	    player = GameObject.Find("Player");
        swan = GameObject.Find("swan");

	    if (cloud == null)
	    {
            cloud = Instantiate(Resources.Load<GameObject>("cloud"),new Vector2(player.transform.position.x+14,player.transform.position.y+5)
                ,Quaternion.identity) as GameObject;
	    }
        
	}

    private void Update()
    {
        MoveCloud();
    }

    void MoveCloud()
    {
        if (cloud != null)
        {
            cloud.transform.Translate(-Vector2.right * cloudSpeed);
        }
    }

    void OnBecameInvisible()
    {
        DestroyImmediate(cloud.gameObject, true);
        if (cloud == null)
        {
            Instantiate(Resources.Load<GameObject>("cloud"), new Vector2(player.transform.position.x + 14, player.transform.position.y + 5), Quaternion.identity);
        }
        
    }

    
}
