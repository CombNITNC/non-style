using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looper : MonoBehaviour {
	[SerializeField] GameObject[] targets = new GameObject[2];
	[SerializeField] float dist;
	[SerializeField] float speed;

	float amount = 0f;

	void Update() {
		amount += speed * Time.deltaTime;
		targets[0].transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime), Space.World);
		targets[1].transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime), Space.World);
		if (dist < amount) {
			var pos = targets[0].transform.position;
			pos.z = dist;
			targets[0].transform.position = pos;
			var tmp = targets[0];
			targets[0] = targets[1];
			targets[1] = tmp;
			amount = 0f;
		}
	}
}