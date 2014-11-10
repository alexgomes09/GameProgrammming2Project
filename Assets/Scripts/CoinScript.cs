using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	private static int currentScore = 0;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
		
			Destroy(this.gameObject);
			currentScore += 100;
		}

		GUIText TotalScore = GameObject.FindWithTag("TotalScore").GetComponent<GUIText>() as GUIText;
		TotalScore.text = "Score : " + currentScore.ToString ();
	}
}
