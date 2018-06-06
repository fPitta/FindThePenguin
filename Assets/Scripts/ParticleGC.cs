using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGC : MonoBehaviour {

	private ParticleSystem ps;

	void Start () {
		ps = GetComponent<ParticleSystem>();
	}

	void Update () {
		if(ps){
			if (!ps.IsAlive()) {	//particle is Alive? If particle is dead, delete the particle obj.
				Destroy (gameObject);
			}
		}
	}
}
