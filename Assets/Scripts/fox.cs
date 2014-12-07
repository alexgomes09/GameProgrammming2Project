using UnityEngine;
using System.Collections;

public class fox : MonoBehaviour
{

    private GameObject player;
    private float foxSpeed = 0.5f;
	void Start ()
	{
	    player = GameObject.Find("Player");
	}
	
	void Update ()
	{
	    gameObject.transform.position = -Vector2.right*foxSpeed*Time.deltaTime;
	}
}
