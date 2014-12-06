using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour {

	private GameObject explosion;
	Animator animator;

	void Start () {
		animator = new Animator();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Cube"){
			this.gameObject.SetActive(false);

			explosion = Instantiate(Resources.Load("rocketExplosion",typeof(GameObject))) as GameObject;

			explosion.transform.position = this.transform.position;

			animator = explosion.GetComponent<Animator>();
			
			if(animator.GetCurrentAnimationClipState(0).Length == 0){
				Destroy(explosion,1f);
			}
		}
	}
}
