using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour {
	[SerializeField] GameObject[] spawnObjects;
	[SerializeField] float cycle = 1.2f;
	[SerializeField] float difficulty = 0.997f;
	float count = 0f;

	// Use this for initialization
	void Start() { }

	// Update is called once per frame
	void Update() {
		if (cycle < count) {
			var i = Random.Range(0, spawnObjects.Length);
			var offset = Random.Range(-4f, 4f);
			var pos = transform.position;
			pos.x += offset;
			Instantiate(spawnObjects[i], pos, Quaternion.identity);
			count = 0f;
			cycle *= difficulty;
		}
		count += Time.deltaTime;
	}
}