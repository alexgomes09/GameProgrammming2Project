using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Transform moveBullet;
    private float speed = 50;
    private float mousePositionX, mousePostiionY;
	void Start () {
	    
	}
	
	void Update ()
	{
        mousePositionX = Input.mousePosition.x;
	    mousePostiionY = Input.mousePosition.y;

	    Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionX, mousePostiionY, Camera.main.fieldOfView));

	    transform.position = Vector2.MoveTowards(transform.position, point,speed*Time.deltaTime);

	    if (transform.position.y > 10 || transform.position.x >10)
	    {
	        Destroy(this.gameObject);
	    }

	}
}
