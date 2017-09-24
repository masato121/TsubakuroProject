using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool ClearFlag;
	public GameObject flyingtsubame;
	public GameObject tsubame;
	public GameObject MiniGame;

	// Use this for initialization
	void Start () {	


		
	}
	
	// Update is called once per frame
	void Update () {
		if (ClearFlag == true) {
			flyingtsubame.active = true;
			MiniGame.active = true;
			tsubame.active = false;
		} else {
			flyingtsubame.active = false;
			MiniGame.active = false;
			tsubame.active = true;
		}
	}
	public void PushClearButton (){
		ClearFlag = true;
	}
	public void PushButtonNoclear(){
		ClearFlag = false;
	}

}
