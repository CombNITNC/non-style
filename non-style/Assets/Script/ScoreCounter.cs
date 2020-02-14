using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
	CollideNoticer noticer;
	[SerializeField] Text countUI;
	int score = 0;

	[SerializeField] AudioClip scoreSE;
	AudioSource scoreSESource;

	[SerializeField] HasLives hurtable;

	// Use this for initialization
	void Start() {
		var player = GameObject.FindWithTag("Player");
		if (player != null) {
			noticer = player.GetComponent<CollideNoticer>();
			if (noticer != null)
				noticer.AddListner(Crushed);
		}

		scoreSESource = GetComponent<AudioSource>();
		if (scoreSESource == null) {
			scoreSESource = gameObject.AddComponent<AudioSource>();
		}
		scoreSESource.clip = scoreSE;
	}

	void Crushed() {
		++score;
		countUI.text = score.ToString("00000");
		scoreSESource.Play();

		if (score % 50 == 0) {
			hurtable.Hurt(-1f);
		}
	}
}