using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HasLives : MonoBehaviour {

	public delegate void OnDeath();

	List<OnDeath> listners = new List<OnDeath>();
	float hitPoint = 0f;
	[SerializeField] float hitLimit = 3f;
	[SerializeField] Text hitUI;

	public void AddListner(OnDeath f) {
		listners.Add(f);
	}

	public void Hurt(float amount) {
		hitPoint += amount;
		if (hitPoint < 0) { hitPoint = 0; }
		hitUI.text = (hitPoint / hitLimit * 100).ToString() + "%";
		if (hitLimit <= hitPoint) {
			foreach (var f in listners) {
				f.Invoke();
			}
		}
	}

}