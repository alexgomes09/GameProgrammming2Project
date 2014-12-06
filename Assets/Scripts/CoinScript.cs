using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
	AudioClip coinSoundClip;
	AudioSource coinSound;

	void Start(){

		coinSound = (AudioSource)gameObject.AddComponent("AudioSource");
		coinSoundClip = (AudioClip)Resources.Load("coin_sound");

		coinSound.clip = coinSoundClip;
		//coinSound.enabled = true;
		coinSound.playOnAwake = false;
	}

	private static int currentScore = 0;
	void OnTriggerEnter2D(Collider2D other)
	{
		coinSound.PlayOneShot(coinSoundClip);
		if (other.tag == "Player") {
			Destroy(this.gameObject,0.2f);
			currentScore += 100;

		}

		GUIText TotalScore = GameObject.FindWithTag("TotalScore").GetComponent<GUIText>() as GUIText;
		TotalScore.text = "Score : " + currentScore.ToString ();
	}
}
