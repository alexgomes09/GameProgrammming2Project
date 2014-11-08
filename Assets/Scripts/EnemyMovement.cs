using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy,target;
    public float speed = 1f;
    private float range;
    public Transform sightStart, sightEnd;

    public bool spotted = false;

	void Start ()
	{
	    enemy = GameObject.FindGameObjectWithTag("Enemy");
	    target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update ()
	{
        
	    RayCasting();
	    Behaviour();
	}

    void RayCasting()
    {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
        spotted = Physics2D.Linecast(sightStart.position, sightEnd.position,1 << LayerMask.NameToLayer("Collision"));
    }

    void Behaviour()
    {
        range = Vector2.Distance(enemy.transform.position, target.transform.position);

        if (range < 5)
        {
            enemy.transform.position = Vector2.MoveTowards(transform.position, target.transform.position,
                speed*Time.deltaTime);

            if (target.transform.position != transform.position)
            {
                Vector3 lookPos = target.transform.position - transform.position;
                float angle = Mathf.Atan2(0, lookPos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle,new Vector3(0,-180,0));
            }

        }else if (range > 5)
        {
            if (spotted)
            {
                transform.Rotate(0, -180f, 0);
                enemy.transform.position -= transform.right * speed * Time.deltaTime;
            }
            else
            {
                transform.Rotate(0, 0, 0);
                enemy.transform.position += transform.right * speed * Time.deltaTime;
            }    
        }
        
    }

}
