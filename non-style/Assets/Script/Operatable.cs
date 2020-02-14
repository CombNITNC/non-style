using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operatable : MonoBehaviour {
	[SerializeField] float steerPower = 0.8f;
	[SerializeField] float controlPower = 0.3f;
	[SerializeField] float controlThershold = 0.06f;
	float steerSpeed = 0f;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		var pos = transform.position;
		if (Input.GetButton("ToRight") && pos.x < 4) {
			steerSpeed += steerPower;
		} else if (Input.GetButton("ToLeft") && -4 < pos.x) {
			steerSpeed -= steerPower;
		} else {
			steerSpeed *= controlPower;
			if (steerSpeed < controlThershold) {
				pos.x = 0f;
			}
		}

		var rotation = Quaternion.Euler(-90, 180 + steerSpeed * 4, 0);
		transform.rotation = rotation;
		transform.Translate(new Vector3(Mathf.Clamp(-steerSpeed / 4, -4, 4), 0, 0));

		pos.x = Mathf.Clamp(steerSpeed, -4, 4);
		transform.position = pos;
	}
}