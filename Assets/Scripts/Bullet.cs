using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private GameObject bulletPrefab,player;
	private GameObject monster;
    private Transform moveBullet;
    private float speed = 300;
    private float mousePositionX, mousePostiionY;

	void Start ()
	{
		Object[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
		if(monsters.Length>0)
		monster = monsters[0] as GameObject;
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
		//collision with monster + bullet
		if (other.gameObject.tag == "Enemy") {
			Destroy(monster);
			//add some score
			GUIText TotalScore = GameObject.FindWithTag("TotalScore").GetComponent<GUIText>() as GUIText;
		 	int restult;
			//Score : 100 -> to 100
			string[] resultArray = TotalScore.text.Split();
			if(resultArray.Length >2)
			{
				if(int.TryParse(resultArray[2],out restult ))
			   	{
					TotalScore.text = "Score : " + (restult + 500).ToString();
				}
			}
		}
	}
}