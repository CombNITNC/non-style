using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackable : MonoBehaviour {
	[SerializeField] float damageAmount = 1f;
	HasLives hurtable;

	// Use this for initialization
	void Start() {
		hurtable = GameObject.FindWithTag("Player").GetComponent<HasLives>();
	}

	// Update is called once per frame
	void Update() {

	}

	void OnTriggerEnter(Collider col) {
		if (col.CompareTag("Player") && hurtable != null) {
			hurtable.Hurt(damageAmount);
		}
	}
}