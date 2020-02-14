using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Crushable : MonoBehaviour {
	[SerializeField] AudioSource bgm;

	// Use this for initialization
	void Start() {

		var hurtable = GameObject.FindWithTag("Player").GetComponent<HasLives>();
		hurtable.AddListner(Crush);
	}

	void Crush() {
		var anim = GetComponent<Animator>();
		anim.SetTrigger("Crush");
		GetComponent<Operatable>().enabled = false;
		GetComponent<HasLives>().enabled = false;
		GetComponent<CollideNoticer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		StartCoroutine(EndGame());
	}

	IEnumerator EndGame() {
		var count = 0f;
		while (count < 2f) {
			count += Time.deltaTime;
			bgm.pitch = 1f - count / 2f;
			yield return null;
		}
		// Get Result
		GameObject.FindWithTag("GameController").GetComponent<Game>().ShowCrushed();
		yield return null;
	}
}