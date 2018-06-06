using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomProcess : MonoBehaviour {

	public GameObject particle;

	void OnCollisionEnter(Collision other){
		GameObject obj = Instantiate (particle);	//particle 생성
		obj.transform.position = transform.position;	//particle 위치를 투사체 위치

		Destroy (gameObject);	//투사체 object delete
	}

	void Start () {}

	void Update () {}
}
