using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PenguinState{
	BossIdle = 0,
	BossWalk,
	BossDamage
}

public class PenguinCtrl : MonoBehaviour {
	PenguinState state = PenguinState.BossIdle;
	float interval = 0;
	Animator ani = null;
	GameObject playerObj;

	void BossIdle () {
		ani.Play ("BossIdle");
		interval += Time.deltaTime;
		if (interval > 2) {
			state = PenguinState.BossWalk;
			interval = 0;
		}
	}

	void BossWalk () {
		Vector3 dir = playerObj.transform.position - transform.position;
		dir.Normalize ();
		dir.y = 0;
		transform.position += dir * 2 * Time.deltaTime;
		Quaternion from = transform.rotation;
		Quaternion to = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.Lerp (from, to, 10 * Time.deltaTime);

		ani.Play ("BossWalk");

		float distance = Vector3.Distance (playerObj.transform.position, transform.position);
		if (distance < 50) {
			dir *= -1;
		}else{
			dir *= 1;
		}

		interval += Time.deltaTime;
		if (interval > 5) {
			state = PenguinState.BossIdle;
			interval = 0;
		}
	}

	void BossDamage () {
		ani.Play ("BossDamage");
		Destroy (gameObject);
	}

	void Start () {
		ani = GetComponent<Animator> ();
		playerObj = GameObject.Find ("Player");
	}
	
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Ball")) {
			state = PenguinState.BossDamage;
		}
	}

	void Update () {
		if (state == PenguinState.BossIdle) {
			BossIdle ();
		} else if (state == PenguinState.BossWalk) {
			BossWalk ();
		} else if (state == PenguinState.BossDamage) {
			BossDamage ();
		}
	}
}
