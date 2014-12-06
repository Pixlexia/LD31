using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMaster : MonoBehaviour {
	public Camera cam;
	public List<GameObject> characters;
	public int currentChar;

	// Use this for initialization
	void Start () {
		currentChar = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			DisableCurrentCharControl();

			if(currentChar > 0)
				currentChar--;
			else
				currentChar = characters.Count - 1;


			SwitchPlayer();
		}
		else if(Input.GetKeyDown(KeyCode.E)){
			DisableCurrentCharControl();

			if(currentChar < characters.Count - 1)
				currentChar++;
			else
				currentChar = 0;

			SwitchPlayer();
		}
	}

	void SwitchPlayer(){
		cam.gameObject.GetComponent<LerpToTarget> ().target = characters [currentChar];
		EnableCurrentCharControl ();
	}
	
	void DisableCurrentCharControl(){
		characters [currentChar].GetComponent<PlayerControl> ().enabled = false;		
		characters [currentChar].GetComponent<FollowPlayer> ().enabled = true;
	}

	void EnableCurrentCharControl(){
		characters [currentChar].GetComponent<PlayerControl> ().enabled = true;		
		characters [currentChar].GetComponent<FollowPlayer> ().enabled = false;		
	}
}
