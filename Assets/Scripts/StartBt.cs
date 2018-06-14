using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBt : MonoBehaviour {
	/*
	GameObject mainCam = null;
	GameObject subCam = null;
	*/

	public void OnClick () {
		SceneManager.LoadScene ("FindThePenguin");
		/*
		GameObject playerCtrl = GameObject.Find ("Player");
		GameObject startCanvas = GameObject.Find ("StartCanvas");

		playerCtrl.GetComponent<PlayerCtrl> ().isAlive = true;
		playerCtrl.GetComponent<FireManager> ().isAlive = true;

		mainCam.GetComponent<Camera>().enabled = true;
		subCam.GetComponent<Camera>().enabled = false;

		mainCam.GetComponent<AudioListener>().enabled = true;
		subCam.GetComponent<AudioListener>().enabled = false;

		startCanvas.GetComponent<Canvas> ().enabled = false;
		*/
	}

	void Start(){
		/*
		mainCam = GameObject.Find ("Main Camera");
		subCam = GameObject.Find ("Sub Camera");

		mainCam.GetComponent<Camera>().enabled = false;
		subCam.GetComponent<Camera>().enabled = true;

		mainCam.GetComponent<AudioListener>().enabled = false;
		subCam.GetComponent<AudioListener>().enabled = true;
		*/
	}
}
