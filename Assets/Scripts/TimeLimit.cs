using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour {
	public Text time = null;
	public float timeCnt;
	public bool isAliveYn = true;

	public void Start () {
		timeCnt = 0;
	}

	public void Update () {
		if (isAliveYn == true) {
			timeCnt += Time.deltaTime;

			time.GetComponent<Text>().text = timeCnt.ToString("00.00").Replace(".",":");

			if(timeCnt >= 30){
				SceneManager.LoadScene ("GameEnd");
			}
		}
	}
}
