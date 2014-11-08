using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy,target;
    public float speed = 1f;
    private float range;
    public Transform sightStart, sightEnd;

    public bool collisionDetected = false;

	void Start ()
	{
	    enemy = GameObject.FindGameObjectWithTag("Enemy"); // gets enemy object 
	    target = GameObject.FindGameObjectWithTag("Player"); // gets target (Player ) object
	}

	void Update ()
	{
	    RayCasting();
	    Behaviour();
	}

    void RayCasting()
    {
        // just drawing a ray cast line in debug mode
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        // if ray cast line end point hits with layer name Collision then  collisionDetected variable becomes true
        collisionDetected = Physics2D.Linecast(sightStart.position, sightEnd.position,1 << LayerMask.NameToLayer("Collision"));
    }

    void Behaviour()
    {
        range = Vector2.Distance(enemy.transform.position, target.transform.position); //gets the range between enemy and target(Player) in this case

        if (range < 5)
        {
            enemy.transform.position = Vector2.MoveTowards(transform.position, target.transform.position,
                speed*Time.deltaTime); // if range less than 5.0f then move enemy towards target(Player)

            //following code gets the target position and translate that to enemy's rotation so enemy can look at target if target range less than 5.0f
            if (target.transform.position != transform.position)
            {
                Vector3 lookPos = target.transform.position - transform.position;  
                float angle = Mathf.Atan2(0, lookPos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle,new Vector3(0,-180,0));
            }

        }else if (range > 5)
        {
            //if range is larger than 5 then keep enemy moving
            if (collisionDetected)
            {
                // if enemy detects collision with world's space (EdgeCollision/Box Collision) then rotate enemy to opposite 
                //degre and keep enemy moving
                transform.Rotate(0, -180f, 0); 
                enemy.transform.position -= transform.right * speed * Time.deltaTime;
            }
            else
            {
                // otherwise rotate enemy to opposite degree and keep enemy moving.
                transform.Rotate(0, 0, 0);
                enemy.transform.position += transform.right * speed * Time.deltaTime;
            }    
        }
        
    }

}
