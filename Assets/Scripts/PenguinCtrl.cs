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

	public Animator ani = null;
	public GameObject playerObj;

	private float interval = 0;
	private float max_Interval = 0;
	private Vector3 p_dir;
	private CharacterController controller;

	void Idle () {
		if (max_Interval < 1) {
			max_Interval = makeInterval ();
		} else {
			ani.Play ("Idle");
			interval += Time.deltaTime;
			if (interval > max_Interval) {
				state = PenguinState.Walk;
				interval = 0;
				max_Interval = 0;
			}
		}
	}

	void Walk () {
		if (max_Interval < 1) {
			max_Interval = makeInterval ();
			p_dir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
			//p_dir.Normalize ();
			p_dir.y = 0;
		} else {
			controller.Move(p_dir * 2 * Time.deltaTime);
			Quaternion from = transform.rotation;
			Quaternion to = Quaternion.LookRotation (p_dir);
			transform.rotation = Quaternion.Lerp (from, to, 10 * Time.deltaTime);

			ani.Play ("Walk");

			interval += Time.deltaTime;
			if (interval > max_Interval) {
				state = PenguinState.Idle;
				max_Interval = 0;
				interval = 0;
			}
		}
	}

	void Damage () {
		ani.Play ("Damage");
		Destroy (gameObject);
	}

	void Start () {
		ani = GetComponent<Animator> ();
		playerObj = GameObject.Find ("Player");
		controller = GetComponent<CharacterController>();
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

	private int makeInterval () {
		float temp_InterVal = Random.Range (1.0f, 10.0f);
		return (int)temp_InterVal;
	}
}
