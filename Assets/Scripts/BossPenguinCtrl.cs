using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossPenguinState{
	BossIdle = 0,
	BossWalk,
	BossDamage
}

public class BossPenguinCtrl : MonoBehaviour {
	BossPenguinState state = BossPenguinState.BossIdle;

	public Animator ani = null;
	public GameObject playerObj;

	private float interval = 0;
	private float max_Interval = 0;
	private Vector3 b_dir;
	private CharacterController controller;

	void BossIdle () {
		if (max_Interval < 1) {
			max_Interval = makeInterval ();
		} else {
			ani.Play ("BossIdle");
			interval += Time.deltaTime;
			if (interval > max_Interval) {
				state = BossPenguinState.BossWalk;
				interval = 0;
				max_Interval = 0;
			}
		}
	}

	void BossWalk () {
		if (max_Interval < 1) {
			max_Interval = makeInterval ();	// 랜덤 워킹 시간 생성
			b_dir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
			b_dir.Normalize ();
			b_dir.y = 0;
		} else {
			controller.Move(b_dir * 2 * Time.deltaTime);
			Quaternion from = transform.rotation;
			Quaternion to = Quaternion.LookRotation (b_dir);
			transform.rotation = Quaternion.Lerp (from, to, 10 * Time.deltaTime);

			ani.Play ("BossWalk");

			/*float distance = Vector3.Distance (playerObj.transform.position, transform.position);
			if (distance < 50) {
				dir *= -1;
			}else{
				dir *= 1;
			}*/

			interval += Time.deltaTime;
			if (interval > max_Interval) {
				state = BossPenguinState.BossIdle;
				max_Interval = 0;
				interval = 0;
			}
		}
	}

	void BossDamage () {
		ani.Play ("BossDamage");
		Destroy (gameObject);
	}

	void Start () {
		ani = GetComponent<Animator> ();
		playerObj = GameObject.Find ("Player");
		controller = GetComponent<CharacterController>();
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Ball")) {
			state = BossPenguinState.BossDamage;
		}
	}

	void Update () {
		if (state == BossPenguinState.BossIdle) {
			BossIdle ();
		} else if (state == BossPenguinState.BossWalk) {
			BossWalk ();
		} else if (state == BossPenguinState.BossDamage) {
			BossDamage ();
		}
	}

	private int makeInterval () {
		float temp_InterVal = Random.Range (1.0f, 10.0f);
		return (int)temp_InterVal;
	}
}
