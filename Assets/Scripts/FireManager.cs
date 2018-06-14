using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour {

	public GameObject snowBall = null;
	public bool isAlive = true;

	void Start () {}

	void Update () {		
		if (Input.GetMouseButtonDown (0) == true) {
			GameObject obj = Instantiate (snowBall);
			obj.transform.position = Camera.main.transform.position;

			Rigidbody rig = obj.GetComponent<Rigidbody> ();
			rig.velocity = Camera.main.transform.forward * 50;	//투사체를 forward 방향으로 속력을 할당.
		}
	}
}
