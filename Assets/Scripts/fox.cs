using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour
{
//
    private GameObject player;
    private float foxSpeed = 1f;

	void Start ()
	{
	    player = GameObject.Find("Player");
	}
	
	void Update ()
	{
	    MoveFox();
	}

    void MoveFox()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * foxSpeed);

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x,transform.position.y), foxSpeed * Time.deltaTime);

            if (player.transform.position != transform.position)
            {
                Vector3 lookPos = player.transform.position - transform.position;
                float angle = Mathf.Atan2(0, lookPos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, -180, 0));
            }
        }
        else if (distance > 5)
        {
            
        }
    }
}
