using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour
{
    private GameObject bomb;
    private GameObject player;
    private float foxSpeed = 1f;
    private float time = 2; 

	void Start ()
	{
	    player = GameObject.Find("Player");
	    bomb = GameObject.Find("bomb");
	}
	
	void Update ()
	{
	    MoveFox();
	}

    void MoveFox()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * foxSpeed);

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= 20)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x,transform.position.y), foxSpeed * Time.deltaTime);

            
            time -= 0.02f;
            if (time <= 0)
            {
                bomb.rigidbody2D.AddForce(player.transform.position,ForceMode2D.Force);
            }
            else
            {
                bomb.transform.position = transform.position;
            }


            if (player.transform.position != transform.position)
            {
                Vector3 lookPos = player.transform.position - transform.position;
                float angle = Mathf.Atan2(0, lookPos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, -180, 0));
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == GameObject.Find("fox").name)
        {
            Physics2D.IgnoreCollision(bomb.collider2D,gameObject.collider2D);
        }
    }
}
