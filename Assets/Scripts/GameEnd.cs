using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void OnClick (){
		SceneManager.LoadScene ("GameStart");
	}

	void Update () {
		
	}
}
