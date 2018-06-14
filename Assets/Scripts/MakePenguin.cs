using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePenguin : MonoBehaviour {
	public GameObject penguin = null;

	public float minPos = -140.0f;
	public float maxPos = 140.0f;

	void Start () {
		GameObject[] obj = new GameObject[170];

		for (int i = 0; i < 170; i++) {
			obj [i] = Instantiate (penguin);

			obj [i].transform.position = new Vector3 (Random.Range(minPos, maxPos), 0 , Random.Range(minPos, maxPos));
		}
	}
}
