using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public GameObject enemy;
    public float speed = 0.3f;
    private GameObject target;
    private float range;

	// Use this for initialization
	void Start ()
	{
	    enemy = GameObject.FindGameObjectWithTag("enemy");
	    target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    range = Vector2.Distance(enemy.transform.position, enemy.transform.position);

	    enemy.transform.position += enemy.transform.position * speed*Time.deltaTime;

	    if (range <= 15f)
	    {
	        //enemy.transform.Translate(Vector2.MoveTowards(enemy.transform.position,target.transform.position,range)*speed*Time.deltaTime);
	    }
	}
}
