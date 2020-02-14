using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
	[SerializeField] float speed = 28f;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
	}
}