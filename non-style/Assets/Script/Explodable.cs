using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Explodable : MonoBehaviour {
	[SerializeField] ParticleSystem explode;
	[SerializeField] GameObject model;
	AudioSource source;

	void Start() {
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider col) {
		if (col.CompareTag("Player")) {
			explode.Play();
			source.Play();
			Destroy(model);
		}
	}
}