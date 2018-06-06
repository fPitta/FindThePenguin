using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PenguinState{
	Idle = 0,
	Walk,
	Damage
}

public class PenguinCtrl : MonoBehaviour {
	PenguinState state = PenguinState.Idle;
	float interval = 0;
	Animator ani = null;
	GameObject playerObj;

	void Idle () {
		ani.Play ("Idle");
		interval += Time.deltaTime;
		if (interval > 2) {
			state = PenguinState.Walk;
			interval = 0;
		}
	}

	void Walk () {
		Vector3 dir = playerObj.transform.position - transform.position;
		dir.Normalize ();
		dir.y = 0;
		transform.position += dir * 2 * Time.deltaTime;
		Quaternion from = transform.rotation;
		Quaternion to = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.Lerp (from, to, 10 * Time.deltaTime);

		ani.Play ("Walk");

		float distance = Vector3.Distance (playerObj.transform.position, transform.position);
		if (distance < 50) {
			dir *= -1;
		}else{
			dir *= 1;
		}

		interval += Time.deltaTime;
		if (interval > 5) {
			state = PenguinState.Idle;
			interval = 0;
		}
	}

	void Damage () {
		ani.Play ("Damage");
		Destroy (gameObject);
	}

	void Start () {
		ani = GetComponent<Animator> ();
		playerObj = GameObject.Find ("Player");
	}
	
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Ball")) {
			state = PenguinState.Damage;
		}
	}

	void Update () {
		if (state == PenguinState.Idle) {
			Idle ();
		} else if (state == PenguinState.Walk) {
			Walk ();
		} else if (state == PenguinState.Damage) {
			Damage ();
		}
	}
}
