using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideNoticer : MonoBehaviour {
	public delegate void Listner();

	List<Listner> listners = new List<Listner>();

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	void OnTriggerEnter(Collider col) {
		if (!col.CompareTag("Enemy")) {
			return;
		}
		foreach (var e in listners) {
			e.Invoke();
		}
	}

	public void AddListner(Listner listner) {
		listners.Add(listner);
	}
}