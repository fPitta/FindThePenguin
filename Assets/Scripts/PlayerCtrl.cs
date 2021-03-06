﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

	private float dirX, dirZ;	//user's input dir.
	private Vector3 dir, velocity;	//chracter's direction and velocity.
	private float SpeedOfChar = 10f;	//character's speed
	private float rotH, rotV = 0f;	//user's input rot.
	private float mouseSensitivity = 2f;	//user's mouseSensitivity
	private CharacterController charCtrl;

	public bool isAlive = true;
	public const float rotVrange = 90;

	void Start () {
		charCtrl = GetComponent<CharacterController> ();
		transform.position = new Vector3 (Random.Range(-100.0f, 100.0f), 2, Random.Range(-100.0f, 100.0f));
	}

	void Update () {
		Move ();	// charCtrl move.
		Rotate ();	// charCtrl change the rotate.

	}

	void Move () {
		dirX = Input.GetAxis ("Horizontal");
		dirZ = Input.GetAxis ("Vertical");

		dir = new Vector3 (dirX, 0f, dirZ);	//can't jump.
		velocity = dir * Time.deltaTime;

		velocity = transform.TransformDirection (velocity);
		velocity = velocity * SpeedOfChar;

		charCtrl.Move(velocity);
	}

	void Rotate(){
		rotH = Input.GetAxis ("Mouse X") * mouseSensitivity;	//Horizontal
		transform.Rotate (0f, rotH, 0f);

		rotV -= Input.GetAxis ("Mouse Y") * mouseSensitivity;	//Vertical
		rotV = Mathf.Clamp(rotV, -rotVrange, rotVrange);
		Camera.main.transform.localRotation = Quaternion.Euler (rotV, 0f, 0f);
	}
}
