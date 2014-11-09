using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private GameObject bulletPrefab,player;

    private Transform moveBullet;
    private float speed = 300;
    private float mousePositionX, mousePostiionY;

	void Start ()
	{
	    bulletPrefab = GameObject.Find("PlayerBullet");
	    player = GameObject.Find("Player");
	}
	
	void Update ()
	{
        mousePositionX = Input.mousePosition.x;
	    mousePostiionY = Input.mousePosition.y;

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionX, mousePostiionY,Camera.main.fieldOfView))-transform.position;
	    transform.rigidbody2D.velocity = point.normalized*speed;

	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(player.GetComponent<CircleCollider2D>(), collider2D);
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(),collider2D);
        }
      
    }
}
